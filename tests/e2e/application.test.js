const given = require("./given");
const when = require("./when");
const then = require("./then");
const { beforeAll } = require("@jest/globals");

describe(`GIVEN application is up and running`, () => {
  let app;
  beforeAll(() => {
    app = given.theApplicationIsUpAndRunning();
  });

  describe("WHEN calling post - /api", () => {
    it(`THEN should return OK-200`, async () => {
      const response = await when.weInvokeEndpoint("post", app.api);
      then.responseIsOk(response);
    });

    describe("WHEN calling get - /calls", () => {
      it(`THEN should return 1 call`, async () => {
        const dependencyCallsResponse = await when.weInvokeEndpoint(
          "get",
          app.api
        );
        then.responseIsOk(dependencyCallsResponse);
        then.responseContains1Call(dependencyCallsResponse);
      });
    });
  });
});
