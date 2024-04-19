// Pass Props to a Stateless Functional Component
const CurrentDate = (props) => {
    return (
      <div>
        { /* Change code below this line */ }
        <p>The current date is: {props.date}</p>
        { /* Change code above this line */ }
      </div>
    );
};
class Calendar extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div>
        <h3>What date is it?</h3>
        { /* Change code below this line */ }
        <CurrentDate date={Date()}/>
        { /* Change code above this line */ }
      </div>
    );
  }
};

// Pass an Array as Props
const List = (props) => {
  { /* Change code below this line */ }
  return <p>{props.tasks.join(', ')}</p>
  { /* Change code above this line */ }
};
class ToDo extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div>
        <h1>To Do Lists</h1>
        <h2>Today</h2>
        { /* Change code below this line */ }
        <List tasks={["walk dog", "workout"]}/>
        <h2>Tomorrow</h2>
        <List tasks={["eat", "sleep", "poop"]}/>
        { /* Change code above this line */ }
      </div>
    );
  }
};

// Default properties and propTypes
const Items = (props) => {
  return <h1>Current Quantity of Items in Cart: {props.quantity}</h1>
};
// Change code below this line
Items.propTypes = {
  quantity: PropTypes.number.isRequired
}
// Change code above this line
Items.defaultProps = {
  quantity: 0
};
class ShoppingCart extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return <Items />
  }
};

// Access Props Using this.props
class App extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
        <div>
            { /* Change code below this line */ }
            <Welcome name={"Uri"}/>
            { /* Change code above this line */ }
        </div>
    );
  }
};
class Welcome extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
        <div>
          { /* Change code below this line */ }
          <p>Hello, <strong>{this.props.name}</strong>!</p>
          { /* Change code above this line */ }
        </div>
    );
  }
};

// Stateful component
class StatefulComponent extends React.Component {
    constructor(props) {
      super(props);
      // Only change code below this line
      this.state = {
        firstName: "Uri"
      }
      // Only change code above this line
    }
    render() {
      return (
        <div>
          <h1>{this.state.firstName}</h1>
        </div>
      );
    }
  };

// SetState
class MyComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: 'Initial State'
    };
    this.handleClick = this.handleClick.bind(this);
  }
  handleClick() {
    // Change code below this line
    this.setState({
      name: 'React Rocks!'
    })
    // Change code above this line
  }
  render() {
    return (
      <div>
        <button onClick={this.handleClick}>Click Me</button>
        <h1>{this.state.name}</h1>
      </div>
    );
  }
};