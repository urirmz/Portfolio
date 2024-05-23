import React from 'react';
import { connect } from 'react-redux';
import { changeText, toggleMaximizeEditor } from '../store';

class Editor extends React.Component {
  constructor(props) {
    super(props);
    this.textChange = this.textChange.bind(this);
    this.toggleMaximize = this.toggleMaximize.bind(this);
  }

  componentDidUpdate() {
    let component = document.getElementById('editor-component');
    if (this.props.hidden) {      
      component.style.display = 'none';
    } else {
      component.style.display = 'block';
    }
  }

  textChange(event) {
    this.props.changeText(event.target.value);
  }

  async toggleMaximize() {
    let editor = document.getElementById('editor');
    let icon = document.getElementById('editor-maximize-icon');

    await this.props.toggleMaximize();

    if (this.props.maximized) {
      editor.style.minHeight = '100vh';
      editor.style.marginBottom = '1em';
      icon.classList.remove('fa-arrows-alt');
      icon.classList.add('fa-compress');
    } else {
      editor.style.minHeight = '15em';
      editor.style.marginBottom = '0';
      icon.classList.remove('fa-compress');
      icon.classList.add('fa-arrows-alt');
    }
  }

  render() {
    return (
      <div id='editor-component' className='container-fluid'>
        <div className='row justify-content-center'>
          <div className='toolbar col-5'>
            Editor
            <i onClick={this.toggleMaximize} id='editor-maximize-icon' className='fa fa-arrows-alt'></i>
          </div>
        </div>
        <div className='row justify-content-center'>
          <textarea onChange={this.textChange} className='col-5' id='editor' value={this.props.editorText}></textarea>
        </div>        
      </div>
    );
  }  
}

function mapStateToProps(state) {
  return {
    editorText: state.textChange.editor,
    maximized: state.maximizeComponents.maximizedEditor,
    hidden: state.maximizeComponents.maximizedPreviewer
  };
};

function mapDispatchToProps(dispatch) {
  return {
    changeText: (text) => {
      dispatch(changeText(text));
    },
    toggleMaximize: () => {
      dispatch(toggleMaximizeEditor());
    }
  }    
}

const connectedComponent = connect(mapStateToProps, mapDispatchToProps) (Editor);

export default connectedComponent;