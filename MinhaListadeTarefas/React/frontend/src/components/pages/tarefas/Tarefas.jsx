import React from "react";

const Tarefas = () => {
    return (
        <div className="container">
            <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Data/Hora</label>
                </div>
                <div className="col-md-2">
                    <input type="datetime-local" className="form-control" />
                </div>
            </div>

            <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Data/Hora</label>
                </div>
                <div className="col-md-2">
                    <input type="datetime-local" className="form-control" />
                </div>
            </div>

            <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Descrição</label>
                </div>
                <div className="col-md">
                    <input type="text" className="form-control" />
                </div>
            </div>

            <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Cetegoria</label>
                </div>
                <div>
                    <select className="form-select col-md-2">

                    </select>
                </div>
            </div>
            <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Prioridade</label>
                </div>
                <div>
                    <select className="form-select col-md-2">
                    </select>
                </div>
            </div>
             <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Resonsável</label>
                </div>
                <div>
                    <select className="form-select col-md-2">
                    </select>
                </div>
            </div>
             <div className="form-group">
                <div className="col-md-2">
                    <label className="form-label">Status</label>
                </div>
                <div>
                    <select className="form-select col-md-2">
                    </select>
                </div>
            </div>
        </div>
    );
}
export default Tarefas;