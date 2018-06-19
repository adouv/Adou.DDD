const path = require('path');
const webpack = require('webpack');
const webpackNotifier = require('webpack-notifier');//通知
const assetsWebpackPlugin = require('assets-webpack-plugin'); // 将每个资源文件的原生filename和chunkhashname一一对应起来的插件 
const cleanWebpackPlugin = require('clean-webpack-plugin'); // 清空目录的插件
const htmlWebpackPlugin = require('html-webpack-plugin');
const extractTextWebpackPlugin = require('extract-text-webpack-plugin');
//const { VueLoaderPlugin } = require('vue-loader');// 添加VueLoaderPlugin，以响应vue-loader

//路径参数
const ENTRY_PATH = path.join(__dirname, './Areas/AdouManage/src/App.js');
const BUNDLE_PATH_ROOT = './Areas/AdouManage/dist';
const CHUNKHASH_NAME = '[name].[hash].js';
const NAME = "[name].js";

//配置
const config = {
    //watch: true,//当改变代码时，会自动更新，除了config
    devtool: 'source-map',//在有bug时，可以看到源码
    entry: [
        path.join(__dirname, './Areas/AdouManage/src/App.js')
    ],//入口文件
    output: {
        path: path.join(__dirname, './Areas/AdouManage/dist'),
        filename: CHUNKHASH_NAME,
        chunkFilename: CHUNKHASH_NAME,
        publicPath: "/Areas/AdouManage/dist/"
    },//出口文件
    resolve: {
        extensions: ['.js', '.vue', '.json'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',//vue编译器
            '@': path.join(__dirname, './Areas/AdouManage/src'),
            '@node': path.join(__dirname, './node_modules'),
            '@view': path.join(__dirname, './Areas/AdouManage/Views')
        }
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                include: [path.join(__dirname, './Areas/AdouManage')]
            },
            {
                test: /\.css$/,
                use: extractTextWebpackPlugin.extract(['css-loader'])
            },
            {
                test: /\.less$/,
                use: extractTextWebpackPlugin.extract(['css-loader', 'less-loader'])
            },
            {
                test: /\.scss$/,
                use: extractTextWebpackPlugin.extract(
                    {
                        fallback: 'style-loader',
                        use: ['css-loader', 'sass-loader']
                    }
                )
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
                loader: 'url-loader',
                options: {
                    limit: 10000,
                    name: path.posix.join('', 'img/[name].[hash:7].[ext]')

                }
            },
            {
                test: /\.(mp4|webm|ogg|mp3|wav|flac|aac)(\?.*)?$/,
                loader: 'url-loader',
                options: {
                    limit: 10000,
                    name: path.posix.join('', 'media/[name].[hash:7].[ext]')
                }
            },
            {
                test: /\.(woff2?|eot|ttf|otf)(\?.*)?$/,
                loader: 'url-loader',
                options: {
                    limit: 10000,
                    name: path.posix.join('', 'fonts/[name].[hash:7].[ext]')
                }
            },
            {
                test: /\.(html|cshtml)$/,
                use: [
                    {
                        loader: 'html-loader',
                        options: {
                            limit: 10000
                        }
                    },
                    {
                        loader: 'iview-loader',
                        options: {
                            prefix: false
                        }
                    }
                ]
            }
        ]
    },//使用babel编译js
    plugins: [
        new cleanWebpackPlugin(path.join(__dirname, './Areas/AdouManage/dist')),//构建前先清空dist文件夹
        //new VueLoaderPlugin(),// 添加VueLoaderPlugin，以响应vue-loader
        new extractTextWebpackPlugin('[name].[hash].css'),
        new assetsWebpackPlugin({
            filename: 'webpack.config.json',
            path: path.join(__dirname, './Areas/AdouManage/dist'),
            prettyPrint: true
        }),//将filename和filename.chunkhash对应起来
        new htmlWebpackPlugin({
            filename: '../Views/Shared/_Layout.cshtml',
            template: './Areas/AdouManage/Views/Shared/_Template.cshtml',
            inject: 'body',
            hash: true,
            minify: {
                removeAttributeQuotes: false // 是否移除属性的引号
            }
        }),
        new webpack.DefinePlugin({
            'process.env': {
                NODE_ENV: '"production"'
            }
        }),
        new webpackNotifier(), // 通知结果
        new webpack.HotModuleReplacementPlugin()
    ]
};

module.exports = config;