const axios = require("axios");

const weInvokeEndpoint = async (method, url) => {
  try {
    const conf = {
      url: url,
      method: method,
    };
    return await axios(conf);
  } catch (err) {
    return err.response;
  }
};

module.exports = {
  weInvokeEndpoint,
};
