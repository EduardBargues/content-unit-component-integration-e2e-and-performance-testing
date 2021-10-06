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

    describe("WHEN calling api-dependency with get - /calls", () => {
      it(`THEN api-dependency should have exactly 1 call stored`, async () => {
        const dependencyCallsResponse = await when.weInvokeEndpoint(
          "get",
          app.calls
        );
        then.responseIsOk(dependencyCallsResponse);
        then.responseContains1Call(dependencyCallsResponse);
      });
    });
  });
});
