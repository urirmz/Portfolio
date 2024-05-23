import { marked } from 'marked';
import { createStore, combineReducers } from 'redux';

const CHANGETEXT = 'CHANGE';

export function changeText(text) {
  return {
    type: CHANGETEXT,
    text: text
  }
};

const textChangeDefaultState = {};
textChangeDefaultState.editor = `# Welcome to my React Markdown Previewer!

  ## This is a sub-heading...
  ### And here's some other cool stuff:
  
  Heres some code, \`<div></div>\`, between 2 backticks.
  
  \`\`\`
  // this is multi-line code:
  
  function anotherExample(firstLine, lastLine) {
    if (firstLine == '\`\`\`' && lastLine == '\`\`\`') {
      return multiLineCode;
    }
  }
  \`\`\`
  
  You can also make text **bold**... whoa!
  Or _italic_.
  Or... wait for it... **_both!_**
  And feel free to go crazy ~~crossing stuff out~~.
  
  There's also [links](https://www.freecodecamp.org), and
  > Block Quotes!
  
  And if you want to get really crazy, even tables:
  
  Wild Header | Crazy Header | Another Header?
  ------------ | ------------- | -------------
  Your content can | be here, and it | can be here....
  And here. | Okay. | I think we get it.
  
  - And of course there are lists.
    - Some are bulleted.
       - With different indentation levels.
          - That look like this.
  
  
  1. And there are numbered lists too.
  1. Use just 1s if you want!
  1. And last but not least, let's not forget embedded images:
  
  ![freeCodeCamp Logo](https://cdn.freecodecamp.org/testable-projects-fcc/images/fcc_secondary.svg)`;
textChangeDefaultState.preview = marked.parse(textChangeDefaultState.editor);

const textChangeReducer = (state = textChangeDefaultState, action) => {
  switch (action.type) {
    case CHANGETEXT: 
      return {
        editor: action.text,
        preview: marked.parse(action.text)
      }
    default:
      return state;
  }
};

const TOGGLEMAXIMIZEEDITOR = 'MAXEDITOR';
const TOGGLEMAXIMIZEPREVIEWER = 'MAXPREVIEW';

export function toggleMaximizeEditor() {
  return {
    type: TOGGLEMAXIMIZEEDITOR
  }
};

export function toggleMaximizePreviewer() {
  return {
    type: TOGGLEMAXIMIZEPREVIEWER
  }
};

let maximizeComponentsDefaultState = { maximizedEditor: false,  maximizedPreviewer: false };

const maximizeComponentsReducer = (state = maximizeComponentsDefaultState, action) => {
  switch (action.type) {    
    case TOGGLEMAXIMIZEPREVIEWER: 
      return {
        maximizedEditor: state.maximizedEditor,
        maximizedPreviewer: !state.maximizedPreviewer
      }
    case TOGGLEMAXIMIZEEDITOR:
      return {
        maximizedEditor: !state.maximizedEditor,
        maximizedPreviewer: state.maximizedPreviewer
      }
    default:
      return state;
  }
};

const rootReducer = combineReducers({
  textChange: textChangeReducer,
  maximizeComponents: maximizeComponentsReducer
}) 

export const store = createStore(rootReducer);