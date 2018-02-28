const path = require("path");
const fableUtils = require("fable-utils");

function resolve(relativePath) {
    return path.join(__dirname, relativePath);
}

module.exports = {
  entry: resolve("src/Client/Client.fsproj"),
  outDir: resolve("out"),
  babel: fableUtils.resolveBabelOptions({
    presets: [["env", { modules: "commonjs" }]],
    sourceMaps: true,
  }),
  fable: {
    define: ["DEBUG"]
  }
}
