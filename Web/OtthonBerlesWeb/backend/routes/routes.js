import express from "express";
import {
    showCustomers,
    showCustomerById,
    createCustomer,
    updateCustomer,
    deleteCustomer,
    loginUser
} from "../controllers/Customers.js";
import {
    showProperties,
    showPropertiesById,
} from "../controllers/Properties.js";

const router = express.Router();

router.get('/customers', showCustomers);

router.get('/properties', showProperties);

router.get('/customers/:id', showCustomerById);

router.get('/properties/:id', showPropertiesById);

router.post('/customers', createCustomer);

router.put('/customers/:id', updateCustomer);

router.delete('/customers/:id', deleteCustomer);


export default router;