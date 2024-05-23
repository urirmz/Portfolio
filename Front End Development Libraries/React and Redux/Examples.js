// Redux:
const ADD = 'ADD';
const addMessage = (message) => {
  return {
    type: ADD,
    message
  }
};
const messageReducer = (state = [], action) => {
  switch (action.type) {
    case ADD:
      return [
        ...state,
        action.message
      ];
    default:
      return state;
  }
};
const store = Redux.createStore(messageReducer);

// React:
class DisplayMessages extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      input: '',
      messages: []
    }
    this.handleChange = this.handleChange.bind(this);
    this.submitMessage = this.submitMessage.bind(this);
  }
  handleChange(event) {
    this.setState({
      input: event.target.value
    });
  }
  submitMessage() {  
    this.setState((state) => {
      const currentMessage = state.input;
      return {
        input: '',
        messages: state.messages.concat(currentMessage)
      };
    });
  }
  render() {
    return (
      <div>
        <h2>Type in a new Message:</h2>
        <input
          value={this.state.input}
          onChange={this.handleChange}/><br/>
        <button onClick={this.submitMessage}>Submit</button>
        <ul>
          {this.state.messages.map( (message, idx) => {
              return (
                 <li key={idx}>{message}</li>
              )
            })
          }
        </ul>
      </div>
    );
  }
};

// Use Provider to Connect Redux to React
const Provider = ReactRedux.Provider;
class AppWrapper extends React.Component {
  // Render the Provider below this line
  render() {
    return (
      <Provider store={store}>
        <DisplayMessages />
      </Provider>
    )       
  }  
  // Change code above this line
};

// Map State to Props
function mapStateToProps(state) {
    return {
      messages: state
    };
};

addMessage = (message) => {
    return {
      type: 'ADD',
      message: message
    }
  };
  
// Map dispatch to props
function mapDispatchToProps(dispatch) {
  return {
    submitNewMessage: (message) => {
      dispatch(addMessage(message));
    }
  }    
}

// Connect Redux to React
class Presentational extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        input: ''
      }
      this.handleChange = this.handleChange.bind(this);
      this.submitMessage = this.submitMessage.bind(this);
    }
    handleChange(event) {
      this.setState({
        input: event.target.value
      });
    }
    submitMessage() {
      this.props.submitNewMessage(this.state.input);
      this.setState((state) => ({
        input: ''
      }));
    }
    render() {
      return (
        <div>
          <h2>Type in a new Message:</h2>
          <input
            value={this.state.input}
            onChange={this.handleChange}/><br/>
          <button onClick={this.submitMessage}>Submit</button>
          <ul>
            {this.props.messages.map( (message, idx) => {
                return (
                   <li key={idx}>{message}</li>
                )
              })
            }
          </ul>
        </div>
      );
    }
  };
const connect = ReactRedux.connect;
const ConnectedComponent = connect(mapStateToProps, mapDispatchToProps) (Presentational);


// Define the Container component here:
const Container = connect(mapStateToProps, mapDispatchToProps)(Presentational);
class AppWrapper extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <Provider store={store}>
        <Container />
      </Provider>
    );
  }
};