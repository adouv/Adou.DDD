const path = require("path");
const utils = require("./build/utils");
const config = require("./config");
const webpack = require("webpack");
const WebpackNotifier = require("webpack-notifier");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const CleanWebpackPlugin = require("clean-webpack-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const OptimizeCSSPlugin = require("optimize-css-assets-webpack-plugin");
const UglifyJsPlugin = require("uglifyjs-webpack-plugin");
const VueLoaderPlugin = require("vue-loader").VueLoaderPlugin;
require("babel-polyfill");

const webpackConfig = {
    context: path.resolve(__dirname, "./"),
    // cheap-module-eval-source-map is faster for development
    devtool: config.build.productionSourceMap ? config.build.devtool : false,
    watch: true,
    //cssSourceMap: false,
    //productionSourceMap: false,
    entry: {
        app: ["babel-polyfill", "./src/main.js"]
    },
    output: {
        path: config.build.assetsRoot,
        filename: utils.assetsPath("js/[name].[hash].js"),
        //filename: utils.assetsPath('js/[name].[hash].js'),
        //chunkFilename: utils.assetsPath('js/[id].[hash].js'),
        publicPath: "/dist/"
    },
    resolve: {
        extensions: [".js", ".vue", ".json"],
        alias: {
            vue$: "vue/dist/vue.esm.js",
            "@": path.join(__dirname, "src"),
            "@views": path.join(__dirname, "src/views"),
            "@lib": path.join(__dirname, "src/assets/lib"),
            "@scss": path.join(__dirname, "src/assets/scss"),
            "@node": path.join(__dirname, "node_modules")
        }
    },
    module: {
        rules: [{
                test: /\.vue$/,
                loader: "vue-loader"
            },
            {
                test: /\.js$/,
                loader: "babel-loader",
                include: [
                    path.join(__dirname, "./src"),
                    path.join(__dirname, "./Areas/AdouManage")
                ]
            },
            {
                test: /\.css$/,
                use: ExtractTextPlugin.extract({
                    use: ["css-loader"],
                    fallback: "vue-style-loader"
                })
            },
            {
                test: /\.less$/,
                use: ExtractTextPlugin.extract({
                    use: ["css-loader", "less-loader"],
                    fallback: "vue-style-loader"
                })
            },
            {
                test: /\.scss$/,
                use: ExtractTextPlugin.extract({
                    use: ["css-loader", "sass-loader"],
                    fallback: "vue-style-loader"
                })
            },
            {
                test: /\.sass/,
                use: ExtractTextPlugin.extract({
                    use: ["css-loader", "sass-loader"],
                    fallback: "vue-style-loader"
                })
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
                loader: "url-loader",
                options: {
                    limit: 10000,
                    name: utils.assetsPath("images/[name].[hash:7].[ext]")
                }
            },
            {
                test: /\.(mp4|webm|ogg|mp3|wav|flac|aac)(\?.*)?$/,
                loader: "url-loader",
                options: {
                    limit: 10000,
                    name: utils.assetsPath("media/[name].[hash:7].[ext]")
                }
            },
            {
                test: /\.(woff2?|eot|ttf|otf)(\?.*)?$/,
                loader: "url-loader",
                options: {
                    limit: 10000,
                    name: utils.assetsPath("fonts/[name].[hash:7].[ext]")
                }
            },
            {
                test: /\.(html|cshtml)$/,
                use: [{
                    loader: "html-loader",
                    options: {
                        limit: 10000
                    }
                }]
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(["dist"], {
            root: __dirname,
            verbose: true,
            dry: false
        }),
        new webpack.DefinePlugin({
            "process.env": {
                NODE_ENV: '"production"'
            }
        }),
        //new UglifyJsPlugin({
        //    uglifyOptions: {
        //        compress: {
        //            warnings: false
        //        }
        //    },
        //    sourceMap: config.build.productionSourceMap,
        //    parallel: true
        //}),
        // extract css into its own file
        new ExtractTextPlugin({
            filename: utils.assetsPath("css/[name].[contenthash].css"),
            // Setting the following option to `false` will not extract CSS from codesplit chunks.
            // Their CSS will instead be inserted dynamically with style-loader when the codesplit chunk has been loaded by webpack.
            // It's currently set to `true` because we are seeing that sourcemaps are included in the codesplit bundle as well when it's `false`,
            // increasing file size: https://github.com/vuejs-templates/webpack/issues/1110
            allChunks: true
        }),
        // Compress extracted CSS. We are using this plugin so that possible
        // duplicated CSS from different components can be deduped.
        new OptimizeCSSPlugin({
            cssProcessorOptions: config.build.productionSourceMap ?
                { safe: true, map: { inline: false } } :
                { safe: true }
        }),
        new VueLoaderPlugin(),
        new HtmlWebpackPlugin({
            filename: "../Areas/AdouManage/Views/Shared/_Layout.cshtml",
            template: "./Areas/AdouManage/Views/Shared/_Template.cshtml",
            inject: "body",
            hash: true,
            minify: {
                removeAttributeQuotes: false
            }
        }),
        // keep module.id stable when vendor modules does not change
        //new webpack.HashedModuleIdsPlugin(),
        // enable scope hoisting
        //new webpack.optimize.ModuleConcatenationPlugin(),
        // split vendor js into its own file
        //new webpack.optimize.CommonsChunkPlugin({
        //    name: 'vendor',
        //    minChunks(module) {
        //        // any required modules inside node_modules are extracted to vendor
        //        return (
        //            module.resource &&
        //            /\.js$/.test(module.resource) &&
        //            module.resource.indexOf(
        //                path.join(__dirname, 'node_modules')
        //            ) === 0
        //        )
        //    }
        //}),
        // extract webpack runtime and module manifest to its own file in order to
        // prevent vendor hash from being updated whenever app bundle is updated
        //new webpack.optimize.CommonsChunkPlugin({
        //    name: 'manifest',
        //    minChunks: Infinity
        //}),
        // This instance extracts shared chunks from code splitted chunks and bundles them
        // in a separate chunk, similar to the vendor chunk
        // see: https://webpack.js.org/plugins/commons-chunk-plugin/#extra-async-commons-chunk
        //new webpack.optimize.CommonsChunkPlugin({
        //    name: 'app',
        //    async: 'vendor-async',
        //    children: true,
        //    minChunks: 3
        //}),
        // copy custom static assets
        new CopyWebpackPlugin([{
            from: path.resolve(__dirname, "src/static"),
            to: config.build.assetsSubDirectory,
            ignore: [".*"]
        }]),
        new WebpackNotifier(),
        new webpack.HotModuleReplacementPlugin()
        //new webpack.BannerPlugin(config.build.banner)
    ]
};

module.exports = webpackConfig;