import{tsConstructureType} from '@babel/types';
import React,{Component} from "react";
import { variables } from "./Variables.js";
export {variables} from './Variables.js';

export class Campaign extends Component{
    constructor(props){
        super(props);

        this.state={
            campaigns:[],
            modalTitle:"",
            CampaignId:0,
            CampaignName:"",
            ProductCode:"",
            Duration:0,
            PMLimit:0,
            TargetSalesCount:0
        }
    }

    refreshList(){
        fetch(variables.API_URL+'Campaign/GetCampaigns')
        .then(response=>response.json())
        .then(data=>{
            this.setState({campaigns:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    changeCampaignName =(e)=>{
        this.setState({CampaignName:e.target.value});
    }

    changeProductCode =(e)=>{
        this.setState({ProductCode:e.target.value});
    }

    changeDuration =(e)=>{
        this.setState({Duration:e.target.value});
    }

    changePMLimit =(e)=>{
        this.setState({PMLimit:e.target.value});
    }

    changeTargetSalesCount =(e)=>{
        this.setState({TargetSalesCount:e.target.value});
    }

    addClick(){
        this.setState({
            modalTitle:"Add Campaign",
            CampaignId:0,
            CampaignName:"",
            ProductCode:"",
            Duration:0,
            PMLimit:0,
            TargetSalesCount:0
        })
    }

    createClick(){
        fetch(variables.API_URL+'Campaign/SaveCampaign',{
            method:"POST",
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Name:this.state.CampaignName,
                ProductCode:this.state.ProductCode,
                Duration:this.state.Duration,
                PriceManipulationLimit:this.state.PMLimit,
                TargetSalesCount:this.state.TargetSalesCount
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        });
    }
    render(){
        const {
            campaigns,
            modalTitle,
            CampaignId,
            CampaignName,
            ProductCode,
            Duration,
            PMLimit,
            TargetSalesCount
        }=this.state;

        return(
            <div>
                <button type="button"
                className="btn btn-primary m-2 float-end"
                data-bs-toggle="modal"
                data-bs-target="#campaignModal"
                onClick={()=>this.addClick()}>
                    Add Campaign
                </button>

                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Campaign Name</th>
                            <th>Product Code</th>
                            <th>Duration</th>
                            <th>Price Manipulation Limit</th>
                            <th>Target Sales Count</th>
                        </tr>
                    </thead>
                    <tbody>
                        {campaigns.map(c=>
                            <tr key={c.Id}>
                                <td>{c.Id}</td>
                                <td>{c.CampaignName}</td>
                                <td>{c.ProductCode}</td>
                                <td>{c.Duration}</td>
                                <td>{c.PriceManipulationLimit}</td>
                                <td>{c.TargetSalesCount}</td>
                            </tr>
                            )}
                        
                    </tbody>
                </table>
                
                <div className="modal fade" id="campaignModal" tabIndex="-1" aria-hidden="true">
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">{modalTitle}</h5>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>

                            <div className="modal-body">
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Campaign Name</span>
                                    <input type="text" className="form-control"
                                    value={CampaignName}
                                    onChange={this.changeCampaignName} />
                                </div>
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Product Code</span>
                                    <input type="text" className="form-control"
                                    value={ProductCode}
                                    onChange={this.changeProductCode} />
                                </div>
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Duration</span>
                                    <input type="text" className="form-control"
                                    value={Duration}
                                    onChange={this.changeDuration} />
                                </div>
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Price Manipulation Limit</span>
                                    <input type="text" className="form-control"
                                    value={PMLimit}
                                    onChange={this.changePMLimit} />
                                </div>
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Target Sales Count</span>
                                    <input type="text" className="form-control"
                                    value={TargetSalesCount}
                                    onChange={this.changeTargetSalesCount} />
                                </div>                                

                                {CampaignId==0?
                                    <button type="button"
                                    className="btn btn-primary float-start"
                                    onClick={()=>this.createClick()}>Create</button>
                                    :null}

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}