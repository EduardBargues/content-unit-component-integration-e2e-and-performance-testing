import http from "k6/http";
import { check } from "k6";
const app = JSON.parse(open("app.json"));

export default function () {
  let resPost = http.post(app.api, {});
  check(resPost, { "sucess post /api": (r) => r.status === 200 });

  let resGet = http.post(app.api, {});
  check(resGet, { "success get /api": (r) => r.status === 200 });
}
