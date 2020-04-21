var path = require("path");

var isGitPod = process.env.GITPOD_INSTANCE_ID !== undefined;

function getDevServerUrl() {
    if (isGitPod) {
        const url = execSync('gp url 8080');
        return url.toString().trim();
    } else {
        return `http://localhost:8080`;
    }
}

module.exports = {
    entry: resolve('./src/TodoMVC.fsproj'),
    mode: "development",
    devtool: "source-map",
    devServer: {
        public: getDevServerUrl(),
        contentBase: resolve("./public"),
        port: 8080,
        host: '0.0.0.0',
        allowedHosts: ['localhost', '.gitpod.io'],
        hot: true,
        inline: true        
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
