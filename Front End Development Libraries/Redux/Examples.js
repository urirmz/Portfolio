// Create a Redux store
const reducer = (state = 5) => {
    return state;
}
const store = Redux.createStore(reducer);

// Get state from Redux store
store = Redux.createStore(
    (state = 5) => state
  );
const currentState = store.getState();

// Define a Redux Action
const action = { type: "LOGIN" };
// Define an action creator here:
function actionCreator() {
    return action;
}

// Dispatch an Action Event
store = Redux.createStore(
    (state = {login: false}) => state
  );  
const loginAction = () => {
  return {
    type: 'LOGIN'
  }
}; 
 // Dispatch the action here:
 store.dispatch(loginAction());

//  Handle an action in the store
const defaultState = {
    login: false
};
reducer = (state = defaultState, action) => {
  // Change code below this line
  if (action.type == 'LOGIN') {
    return { login: true };
  } else {
    return state;
  }
  // Change code above this line
};  
store = Redux.createStore(reducer); 
loginAction = () => {
  return {
    type: 'LOGIN'
  }
};

// Use a Switch Statement to Handle Multiple Actions
defaultState = {
    authenticated: false
};  
const authReducer = (state = defaultState, action) => {
  // Change code below this line
  let newState = { ...state };
  switch (action.type) {
    case 'LOGIN':
      newState.authenticated = true;
      break;
    case 'LOGOUT':
      newState.authenticated = false;
  }
  return newState;
  // Change code above this line
};
store = Redux.createStore(authReducer);
const loginUser = () => {
  return {
    type: 'LOGIN'
  }
};
const logoutUser = () => {
  return {
    type: 'LOGOUT'
  }
};

// Use const for Action Types
const LOGIN = 'LOGIN';
const LOGOUT = 'LOGOUT';
defaultState = {
  authenticated: false
};
authReducer = (state = defaultState, action) => {
  switch (action.type) {
    case LOGIN: 
      return {
        authenticated: true
      }
    case LOGOUT: 
      return {
        authenticated: false
      }
    default:
      return state;
  }
};
store = Redux.createStore(authReducer);
loginUser = () => {
  return {
    type: LOGIN
  }
};
logoutUser = () => {
  return {
    type: LOGOUT
  }
};

// Register a Store Listener
const ADD = 'ADD';
reducer = (state = 0, action) => {
  switch(action.type) {
    case ADD:
      return state + 1;
    default:
      return state;
  }
};
store = Redux.createStore(reducer);
// Global count variable:
let count = 0;
// Change code below this line
store.subscribe(() => {
  count++;
});
// Change code above this line
store.dispatch({type: ADD});
console.log(count);
store.dispatch({type: ADD});
console.log(count);
store.dispatch({type: ADD});
console.log(count);

// Combine multiple reducers
const INCREMENT = 'INCREMENT';
const DECREMENT = 'DECREMENT';
const counterReducer = (state = 0, action) => {
  switch(action.type) {
    case INCREMENT:
      return state + 1;
    case DECREMENT:
      return state - 1;
    default:
      return state;
  }
};
LOGIN = 'LOGIN';
LOGOUT = 'LOGOUT';
authReducer = (state = {authenticated: false}, action) => {
  switch(action.type) {
    case LOGIN:
      return {
        authenticated: true
      }
    case LOGOUT:
      return {
        authenticated: false
      }
    default:
      return state;
  }
};
// Define the root reducer here
const rootReducer = Redux.combineReducers({
  count: counterReducer,
  auth: authReducer
}) 
store = Redux.createStore(rootReducer);

// Send Action Data to the store
const ADD_NOTE = 'ADD_NOTE';
const notesReducer = (state = 'Initial State', action) => {
  switch(action.type) {
    // Change code below this line
    case ADD_NOTE:
      return action.text;
    // Change code above this line
    default:
      return state;
  }
};
const addNoteText = (note) => {
  // Change code below this line
  return { type: ADD_NOTE, text: note };
  // Change code above this line
};
store = Redux.createStore(notesReducer);
console.log(store.getState());
store.dispatch(addNoteText('Hello!'));
console.log(store.getState());

// Use middleware to handle asynchronous actions
const REQUESTING_DATA = 'REQUESTING_DATA'
const RECEIVED_DATA = 'RECEIVED_DATA'
const requestingData = () => { return {type: REQUESTING_DATA} }
const receivedData = (data) => { return {type: RECEIVED_DATA, users: data.users} }
const handleAsync = () => {
  return function(dispatch) {
    // Dispatch request action here
    dispatch(requestingData());
    setTimeout(function() {
      let data = {
        users: ['Jeff', 'William', 'Alice']
      }
      // Dispatch received data action here
      dispatch(receivedData(data));
    }, 2500);
  }
};
defaultState = {
  fetching: false,
  users: []
};
const asyncDataReducer = (state = defaultState, action) => {
  switch(action.type) {
    case REQUESTING_DATA:
      return {
        fetching: true,
        users: []
      }
    case RECEIVED_DATA:
      return {
        fetching: false,
        users: action.users
      }
    default:
      return state;
  }
};
store = Redux.createStore(
  asyncDataReducer,
  Redux.applyMiddleware(ReduxThunk.default)
);

// Write a Counter with Redux
INCREMENT = 'INCREMENT'; // Define a constant for increment action types
DECREMENT = 'DECREMENT'; // Define a constant for decrement action types
counterReducer = (state = 0, action) => {
  switch (action.type) {
    case INCREMENT:
      return ++state;
    case DECREMENT:
      return --state;
    default:
      return state;
  }
}; // Define the counter reducer which will increment or decrement the state based on the action it receives
const incAction = () => {
  return { type: INCREMENT };
}; // Define an action creator for incrementing
const decAction = () => {
  return { type: DECREMENT };
}; // Define an action creator for decrementing
store = Redux.createStore(counterReducer); // Define the Redux store here, passing in your reducers

// Never Mutate State
const ADD_TO_DO = 'ADD_TO_DO';
// A list of strings representing tasks to do:
const todos = [
  'Go to the store',
  'Clean the house',
  'Cook dinner',
  'Learn to code',
];
const immutableReducer = (state = todos, action) => {
  switch(action.type) {
    case ADD_TO_DO:
      // Don't mutate state here or the tests will fail
      return state.concat(action.todo);
    default:
      return state;
  }
};
const addToDo = (todo) => {
  return {
    type: ADD_TO_DO,
    todo
  }
}
store = Redux.createStore(immutableReducer);

// Use the spread operator on arrays
immutableReducer = (state = ['Do not mutate state!'], action) => {
  switch(action.type) {
    case 'ADD_TO_DO':
      // Don't mutate state here or the tests will fail
      return [ ...state, action.todo ];
    default:
      return state;
  }
};
addToDo = (todo) => {
  return {
    type: 'ADD_TO_DO',
    todo
  }
}
store = Redux.createStore(immutableReducer);

// Remove an item from an array
immutableReducer = (state = [0,1,2,3,4,5], action) => {
  switch(action.type) {
    case 'REMOVE_ITEM':
      // Don't mutate state here or the tests will fail
      const firstHalf = state.slice(0, action.index);
      const secondHalf = state.slice(action.index + 1, action.length);
      return firstHalf.concat(secondHalf);
    default:
      return state;
  }
};
const removeItem = (index) => {
  return {
    type: 'REMOVE_ITEM',
    index
  }
}
store = Redux.createStore(immutableReducer);

// Copy an Object with Object.assign
defaultState = {
  user: 'CamperBot',
  status: 'offline',
  friends: '732,982',
  community: 'freeCodeCamp'
};
immutableReducer = (state = defaultState, action) => {
  switch(action.type) {
    case 'ONLINE':
      // Don't mutate state here or the tests will fail
      return Object.assign({}, state, { status: 'online'});
    default:
      return state;
  }
};
const wakeUp = () => {
  return {
    type: 'ONLINE'
  }
};
store = Redux.createStore(immutableReducer);