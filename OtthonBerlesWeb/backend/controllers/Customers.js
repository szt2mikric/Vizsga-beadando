import {
    getCustomers,
    getCustomerById,
    insertCustomer,
    updateCustomerById,
    deleteCustomerById,
    findUserByEmailAndPassword,
} from "../models/CustomersModel.js";

export const showCustomers =(req, res)=>{
    getCustomers((err, results)=>{
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};

export const showCustomerById=(req, res) =>{
    getCustomerById(req.params.id,(err, results)=>{
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};

export const createCustomer = (req, res) =>{
    const data = req.body;
    insertCustomer(data, (err, results) =>{
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};

export const updateCustomer =(req, res) =>{
    const data = req.body;
    const id = req.params.id;
    updateCustomerById(data, id, (err, results) =>{
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};

export const deleteCustomer=(req, res) =>{
    const id = req.params.id;
    deleteCustomerById(id, (err, results) =>{
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};

export const loginUser = async (req, res) => {
    const { email, password } = req.body;
    try {
        const user = await findUserByEmailAndPassword(email, password);   
        if (user) {
            res.json({ success: true, message: "Sikeres bejelentkezés" });
        } else {
            res.json({ success: false, message: "Hibás email cím vagy jelszó" });
        }
    } catch (err) {
        console.log(err);
        res.status(500).json({ success: false, message: "Hiba történt a bejelentkezés során" });
    }
};

  


