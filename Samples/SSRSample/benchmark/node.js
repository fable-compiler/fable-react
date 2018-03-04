const cluster = require('cluster');
const http = require('http');
const View = require('../src/Client/bin/lib/View')
const ReactDOMServer = require('react-dom/server')
const os = require('os')
const coreCount = os.cpus().length;

const initState = {
  counter: 42,
  someString: "Some String",
  someFloat: 11.11,
  someInt: 22,
}

const noop = () => {}
const mb = bytes => (bytes / 1024 / 1024).toFixed(3)
const workerTimes = 5000
const totalTimes = workerTimes * coreCount

function render(len = workerTimes) {
  const start = Date.now()
  while (len--) {
    ReactDOMServer.renderToString(View.view(initState, noop))
  }
  return Date.now() - start
}

function singleTest() {
  const times = workerTimes * 2
  const time = render(times)
  console.log(`[Single process] ${time}ms    ${(times / time * 1000).toFixed(3)}req/s`)
}

if (cluster.isMaster) {
  console.log(`Master ${process.pid} is running`);

  singleTest()

  // Fork workers.
  for (let i = 0; i < coreCount; i++) {
    const worker = cluster.fork();
  }

  let totalms = 0
  let count = 0
  let memoryUsed = 0
  function messageHandler(msg) {
    if (msg.cmd === 'finished') {
      count++
      totalms = totalms + msg.time
      memoryUsed += msg.memory
      if (count >= coreCount) {
        totalms = totalms / coreCount
        console.log(`[${coreCount} workers] Total: ${totalms}ms    Memory footprint: ${mb(memoryUsed)}MB    Requests/sec: ${(totalTimes / totalms * 1000).toFixed(3)}`)
        for (const id in cluster.workers) {
          cluster.workers[id].destroy()
        }
        process.exit(0)
      }
    }
  }

  for (const id in cluster.workers) {
    cluster.workers[id].on('message', messageHandler);
  }
  cluster.on('exit', (worker, code, signal) => {
    console.log(`worker ${worker.process.pid} died`);
  });
} else {
  console.log(`Worker ${process.pid}: started`);
  const time = render()
  console.log(`Worker ${process.pid}: render ${workerTimes} times used ${time}ms`)
  const mem = process.memoryUsage()
  process.send({
    cmd: 'finished',
    time,
    memory: mem.heapTotal + mem.external
  })
}
