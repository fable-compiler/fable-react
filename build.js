var path = require("path");
var fs = require("fs-extra");
var fable = require("fable-compiler");

function promise(f) {
    var args = Array.from(arguments).slice(1);
    return new Promise(function (resolve, reject) {
        args.push(function (err, data) {
            if (err) { reject(err); } else { resolve(data); }
        });
        f.apply(this, args);
    });
}

var targets = {
    all() {
        return promise(fs.remove, "npm")
            .then(_ => fable.compile())
            .then(_ => promise(fs.copy, "package.json", "npm/package.json"))
            .then(_ => promise(fs.copy, "README.md", "npm/README.md"))
            .then(_ => promise(fs.readFile, "RELEASE_NOTES.md"))
            .then(line => {
                var version = /\d[^\s]*/.exec(line)[0];
                return fable.runCommand("npm", "npm version " + version);
            });
    }
}

targets[process.argv[2] || "all"]().catch(err => {
    console.log("[ERROR] " + err);
    proccess.exit(-1);
});
