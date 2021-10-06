const HTTP_STATUS_CODE_OK = 200;

const responseIsOk = (response) => {
  expect(response.status).toBe(HTTP_STATUS_CODE_OK);
};
const responseContains1Call = (response) => {
  expect(response.data.length).toBe(1);
};

module.exports = {
  responseIsOk,
  responseContains1Call,
};
