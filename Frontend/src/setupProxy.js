const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/skishop",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:5001/api/Products',
        secure: false
    });

    app.use(appProxy);
};
