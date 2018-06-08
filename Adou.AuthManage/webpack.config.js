const path = require('path');
const webpack = require('webpack');
const webpackNotifier = require('webpack-notifier');//通知
const assetsWebpackPlugin = require('assets-webpack-plugin'); // 将每个资源文件的原生filename和chunkhashname一一对应起来的插件 
const cleanWebpackPlugin = require('clean-webpack-plugin'); // 清空目录的插件
const htmlWebpackPlugin = require('html-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');// 添加VueLoaderPlugin，以响应vue-loader

//路径参数
const ENTRY_PATH = path.join(__dirname, './Areas/AdouManage/src/App.js');
const BUNDLE_PATH_ROOT = './Areas/AdouManage/dist';
const CHUNKHASH_NAME = '[name].[hash].js';
const NAME = "[name].js";

//配置
const config = {
    //devServer: { //这没什么用到，就是在开发时的设定，我一般都是直接production
    //    port: 4200,
    //    overlay: {
    //        errors: true,
    //        // warnings : true
    //    }
    //},
    watch: true,//当改变代码时，会自动更新，除了config
    devtool: 'source-map',//在有bug时，可以看到源码
    entry: [
        path.join(__dirname, './Areas/AdouManage/src/App.js')
    ],//入口文件
    output: {
        path: path.join(__dirname, './Areas/AdouManage/dist/js'),
        filename: CHUNKHASH_NAME,
        chunkFilename: CHUNKHASH_NAME,
        publicPath: "~/Areas/AdouManage/dist/js"
    },//出口文件
    resolve: {
        extensions: ['.js', '.vue', '.json'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        }//vue编译器
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    // vue-loader options go here
                }
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015', 'es2016']
                },
                exclude: /node_modules/
            },
            {
                test: /(\.css$)/,
                loaders: ['style-loader', 'css-loader']
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
                loader: 'url-loader',
                options: {
                    limit: 10000,
                    name: path.join(__dirname, './Areas/AdouManage/dist/img/[name].[hash:7].[ext]')

                }
            },
            {
                test: /\.(mp4|webm|ogg|mp3|wav|flac|aac)(\?.*)?$/,
                loader: 'url-loader',
                options: {
                    limit: 10000,
                    name: path.join(__dirname, './Areas/AdouManage/dist/media/[name].[hash:7].[ext]')
                }
            },
            {
                test: /\.(woff2?|eot|ttf|otf)(\?.*)?$/,
                loader: 'url-loader',
                options: {
                    limit: 10000,
                    name: path.join(__dirname, './Areas/AdouManage/dist/fonts/[name].[hash:7].[ext]')
                }
            }
        ]
    },//使用babel编译js
    plugins: [
        new cleanWebpackPlugin(path.join(__dirname, './Areas/AdouManage/dist')),//构建前先清空dist文件夹
        new VueLoaderPlugin(),// 添加VueLoaderPlugin，以响应vue-loader
        new assetsWebpackPlugin({
            filename: 'webpack.config.json',
            path: path.join(__dirname, './Areas/AdouManage/dist'),
            prettyPrint: true
        }),//将filename和filename.chunkhash对应起来
        new htmlWebpackPlugin({
            filename: '../../Views/Shared/_Layout.cshtml',
            template: './Areas/AdouManage/Views/Shared/Template.cshtml',
            inject: 'body'
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