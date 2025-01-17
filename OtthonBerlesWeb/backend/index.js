import express from "express";
import cors from "cors";
import Router from "./routes/routes.js";

const app = express();

app.use(express.json());

app.use(cors());

app.use(Router);

import { loginUser } from "./controllers/Customers.js";

app.post('/login', loginUser);

app.listen(3000, () => {
    console.log("A szerver fut");
});
