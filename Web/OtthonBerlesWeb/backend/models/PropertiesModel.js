import db from "../cofig/database.js";

export const getProperties =(result) =>{
    db.query("SELECT * FROM properties", 
    (err,results)=>{
        if(err){
            console.log(err);
            result(err, null);
        } else{
            result(null, results);
        }
    });
};

export const getPropertiesById=(id, result) =>{
    db.query("SELECT * FROM properties WHERE ID =?",
    [id], 
    (err, results)=>{
        if(err){
            console.log(err);
            result(err, null);
        } else{
            result(null, results);
        }
    });
};