const path = require('path');

module.exports = {
    entry: ["babel-polyfill", './src/js/app.js'],
    output: {
        path: path.resolve(__dirname, "public/js"),
        filename: 'bundle.js'
    },
    module: {
        rules: [{
            test: /\.js$/,
            exclude: /node_modules/,
            use: {
                loader: 'babel-loader',
                options: {
                    presets: ['env']
                }
            }
        }]
    },
    devServer: {
        contentBase: path.resolve(__dirname, "public"),
        publicPath: '/js/'
    },
    devtool: 'source-map'
}