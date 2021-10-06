const appFile = require("./app.json");

const theApplicationIsUpAndRunning = () => {
  const app = {
    dotnetWebApiEndpoint: appFile.endpoints.value._dotnet_webapi,
  };
  return app;
};

module.exports = { theApplicationIsUpAndRunning };
