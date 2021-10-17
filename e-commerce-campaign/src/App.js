import logo from './logo.svg';
import './App.css';
// import {Home} from './Home';
import {Product} from './Product';
import {Order} from './Order';
import {Campaign} from './Campaign';
import {BrowserRouter,Route,Switch,NavLink} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="App container">
      <h3 className="d-flex justify-content-center m-3">
          E-Commerce Campaign
      </h3>

      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
        <ul className="navbar-nav">
          {/* <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/home">
              Home
            </NavLink>
          </li> */}
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/product">
              Product
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/order">
              Order
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/campaign">
              Campaign
            </NavLink>
          </li>
        </ul>
      </nav>

      <Switch>
        {/* <Route path='/home' component={Home}/> */}
        <Route path='/product' component={Product}/>
        <Route path='/order' component={Order}/>
        <Route path='/campaign' component={Campaign}/>
      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
