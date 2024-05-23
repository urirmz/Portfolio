import React from 'react';
import { connect } from 'react-redux';
import { toggleMaximizePreviewer } from '../store';

class Previewer extends React.Component {
  constructor(props) {
    super(props);
    this.toggleMaximize = this.toggleMaximize.bind(this);
  }

  componentDidUpdate() {
    let component = document.getElementById('previewer-component');
    if (this.props.hidden) {      
      component.style.display = 'none';
    } else {
      component.style.display = 'block';
    }
  }

  async toggleMaximize() {
    let preview = document.getElementById('previewer-component');
    let icon = document.getElementById('previewer-maximize-icon');

    await this.props.toggleMaximize();
    
    if (this.props.maximized) {
      preview.style.minHeight = '100vh';
      icon.classList.remove('fa-arrows-alt');
      icon.classList.add('fa-compress');
    } else {
      preview.style.minHeight = '70vh';
      icon.classList.remove('fa-compress');
      icon.classList.add('fa-arrows-alt');
    }
  }

  render() {
    return (
      <div className='container-fluid' id='previewer-component'>
        <div className='row justify-content-center'>
          <div className='toolbar col-7'>
            Previewer
            <i onClick={this.toggleMaximize} id='previewer-maximize-icon' className='fa fa-arrows-alt'></i>
          </div>
        </div>
        <div className='row justify-content-center'>
          <div className='col-7' id='previewer' dangerouslySetInnerHTML={{ __html: this.props.preview }}>
          </div>
        </div>        
      </div>
    );
  }  
}

function mapStateToProps(state) {
  return {
    preview: state.textChange.preview,
    maximized: state.maximizeComponents.maximizedPreviewer,
    hidden: state.maximizeComponents.maximizedEditor
  };
};

function mapDispatchToProps(dispatch) {
  return { 
    toggleMaximize: () => {
      dispatch(toggleMaximizePreviewer());
    }
  }    
}

const connectedComponent = connect(mapStateToProps, mapDispatchToProps) (Previewer);

export default connectedComponent;