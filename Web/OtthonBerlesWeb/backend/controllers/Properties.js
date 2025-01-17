import {
    getProperties,
    getPropertiesById,
} from "../models/PropertiesModel.js";

export const showProperties =(req, res) =>{
    getProperties((err, results) => {
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};

export const showPropertiesById = (req, res) =>{
    getPropertiesById(req.params.id,(err, results) =>{
        if(err){
            res.send(err);
        } else{
            res.json(results);
        }
    });
};