var path = require("path");

module.exports = {
    entry: resolve('./src/TodoMVC.fsproj'),
    mode: "development",
    devtool: "source-map",
    devServer: {
        contentBase: resolve("./public"),
        port: 8080,
    },
    module: {
        rules: [
            {
                test: /\.fs(x|proj)?$/,
                use: "fable-loader"
            }
        ]
    },
    externals: {
        "react": "React",
        "react-dom": "ReactDOM",
    },
};

function resolve(filePath) {
    return path.isAbsolute(filePath) ? filePath : path.join(__dirname, filePath);
}