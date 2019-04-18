module.exports = {
    entry: './src/TodoMVC.fsproj',
    mode: "development",
    devtool: "source-map",
    devServer: {
        contentBase: "./public",
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