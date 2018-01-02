var path = require("path");
var webpack = require("webpack");
var fableUtils = require("fable-utils");

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = fableUtils.resolveBabelOptions({
  presets: [
    ["env", {
      "targets": {
        "browsers": "> 1%"
      },
      "modules": false
    }]
  ],
});

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
  devtool: "source-map",
  entry: resolve('Fable.Recharts.Sample.fsproj'),
  output: {
    filename: 'bundle.js',
    path: resolve('.'),
  },
  resolve: {
    modules: [resolve("./node_modules/")]
  },
  devServer: {
    contentBase: resolve('.'),
    port: 8080
  },
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: isProduction ? [] : ["DEBUG"]
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      }
    ]
  }
};
