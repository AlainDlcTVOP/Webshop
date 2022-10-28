import logo from './logo.svg';
import ProductDetials from './components/ProductDetials';
import Productoverview from './components/Productoverview';
import Admin from './components/Admin';
import Shoppingcart from './components/Shoppingcart';
import Loginregistration from './components/Loginregistration';
import Customer from './components/Customer';
import Home from './components/Home';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <ProductDetials />
        <Productoverview />
        <Home />
        <Admin />
        <Shoppingcart />
        <Loginregistration />
        <Customer/>
      </header>
    </div>
  );
}

export default App;
