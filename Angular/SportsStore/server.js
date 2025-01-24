const jsonServer = require('json-server');
const server = jsonServer.create();
const router = jsonServer.router('data.json');
const middlewares = jsonServer.defaults();
const authMiddleware = require('./authMiddleware');

server.use(authMiddleware);
server.use(middlewares);
server.use(router);

server.listen(3500, () => {
  console.log('Json Server is running on http.//localhost:3500');
})
