import React, { Component } from 'react';
import ParticlesBg from 'particles-bg'
import Navigation from './components/Navigation';
import Login from './components/Login';
import Register from './components/Register';
import './App.css';


class App extends Component {
  constructor() {
    super();
    this.state = {
      input: '',
    
      route: 'login',
      isSignedIn: false,
      user: {
        id: '',
        name: '',
        email: '',
    
      }
    }
  }

  loadUser = (data) => {
    this.setState({user: {
      id: data.id,
      name: data.name,
      email: data.email,
     
    }})
  }

  

  onInputChange = (event) => {
    this.setState({input: event.target.value});
  }

  
  onRouteChange = (route) => {
    if (route === 'signout') {
      this.setState({isSignedIn: false})
    } else if (route === 'home') {
      this.setState({isSignedIn: true})
    }
    this.setState({route: route});
  }

  render() {
    const { isSignedIn,  route } = this.state;
    return (
      <div className="App">
     {/* <ParticlesBg className="particles" bg={true}  num={15}/> */}
        <Navigation isSignedIn={isSignedIn} onRouteChange={this.onRouteChange} />
        { route === 'home'
          ? <div>
              
            
            </div>
          : (
             route === 'login'
             ? <Login loadUser={this.loadUser} onRouteChange={this.onRouteChange}/>
             : <Register loadUser={this.loadUser} onRouteChange={this.onRouteChange}/>
            )
        }
      </div>
    );
  }
}

export default App;