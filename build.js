var path = require("path");
var fs = require("fs-extra");
var fable = require("fable-compiler");

var targets = {
    all() {
        return fable.promise(fs.remove, "npm")
            .then(_ => fable.compile())
            .then(_ => fable.promise(fs.copy, "package.json", "npm/package.json"))
            .then(_ => fable.promise(fs.copy, "README.md", "npm/README.md"))
            .then(_ => fable.promise(fs.readFile, "RELEASE_NOTES.md"))
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
