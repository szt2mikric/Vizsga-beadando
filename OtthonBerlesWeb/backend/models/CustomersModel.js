import db from "../cofig/database.js";

export const getCustomers =(result) =>{
    db.query("SELECT * FROM customers ", 
    (err, results)=>{
        if(err){
            console.log(err);
            result(err, null);
        } else{
            result(null, results);
        }
    });
};

export const getCustomerById=(id, result) =>{
    db.query("SELECT *FROM customers WHERE ID = ?", 
    [id],
    (err, results) =>{
        if(err){
            console.log(err);
            result(err, null);
        } else{
            result(null, results);
        }
    });
};

export const insertCustomer = (data, result) => {
    const { Customer_fullname, Customer_email, Customer_password } = data;
    db.query(
        "INSERT INTO customers (Customer_fullname, Customer_email, Customer_password) VALUES (?, ?, ?)",
        [Customer_fullname, Customer_email, Customer_password],
        (err, results) => {
            if (err) {
                console.log(err);
                result(err, null);
            } else {
                result(null, results);
            }
        }
    );
};


export const updateCustomerById =(data, id, result) => {
    db.query("UPDATE customers SET Customer_fullname = ?, Customer_email = ?, Customer_password = ? WHERE ID = ?", 
    [data.Customer_fullname, data.Customer_email, data.Customer_password, id], 
    (err, results) => { 
        if(err){
            console.log(err);
            result(err, null);
        } else{
            result(null, results);
        }
    });
};

export const deleteCustomerById =(id, result) =>{
    db.query("DELETE FROM customers WHERE ID = ?", 
    [id], 
    (err, results) =>
    {
        if(err){
            console.log(err);
            result(err, null);
        } else{
            result(null, results);
        }
    });
};

export const findUserByEmailAndPassword = async (email, password) => {
    try {
        const [user] = await db.query("SELECT * FROM customers WHERE Customer_email = ? AND Customer_password = ?", [email, password]);
        return user; 
    } catch (err) {
        console.log(err);
        throw err;
    }
};




  