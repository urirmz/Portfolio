import React from 'react';
import './App.css';
import $ from 'jquery';

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      quote: new Quote(),
      color: []
    }
    this.newQuoteAndColor = this.newQuoteAndColor.bind(this);
  }

  componentDidMount() {    
    this.newQuoteAndColor();
  }

  render() {  
    const mainColor = `rgb(${this.state.color[0]}, ${this.state.color[1]}, ${this.state.color[2]})`;
    const spaceQuoteIcons = {marginLeft: 10, marginRight: 10};

    return (      
      <div id="page" className="container-fluid row align-items-center fade-in" style={{backgroundColor: mainColor}}>
        <div id="quote-box" className="container-sm col-4 rounded-2">
          <p id="text" className="fade-in" style={{color: mainColor}}>
            <i className="fa fa-quote-left" style={spaceQuoteIcons}></i>
            {this.state.quote.phrase}
            <i className="fa fa-quote-right" style={spaceQuoteIcons}></i>
          </p>
          <p id="author" className="fade-in" style={{color: mainColor}}>- {this.state.quote.author}</p>
          <div className="buttons row gap-2">
            <a className="btn btn-default col-1 rounded-1 fade-in" style={{backgroundColor: mainColor, color: "white"}}>
              <i className="fa fa-twitter"></i>
            </a>
            <a className="btn btn-default col-1 rounded-1 fade-in" style={{backgroundColor: mainColor, color: "white"}}>
              <i className="fa fa-tumblr"></i>
            </a>
            <button id="new-quote" className="btn btn-default col-auto ms-auto rounded-1 fade-in" onClick={this.newQuoteAndColor} style={{background: mainColor}}>
              New quote
            </button>
          </div>          
        </div>
      </div>
      
    );
  }

  newQuoteAndColor() {
    const r = Math.floor(Math.random() * 255);
    const g = Math.floor(Math.random() * 255);
    const b = Math.floor(Math.random() * 255);
    const color = [r, g, b];
  
    const quotes = [];
    quotes.push(new Quote("There are no traffic jams along the extra mile.", "Roger Staubach")); 
    quotes.push(new Quote("If the wind will not serve, take to the oars.", "Latin Proverb")); 
    quotes.push(new Quote("What’s money? A man is a success if he gets up in the morning and goes to bed at night and in between does what he wants to do.", "Bob Dylan")); 
    quotes.push(new Quote("Everything you’ve ever wanted is on the other side of fear.", "George Addair")); 
    quotes.push(new Quote("You can’t use up creativity. The more you use, the more you have.", "Maya Angelou"));
    quotes.push(new Quote("Remember no one can make you feel inferior without your consent.", "Eleanor Roosevelt"));
    quotes.push(new Quote("I have been impressed with the urgency of doing. Knowing is not enough; we must apply. Being willing is not enough; we must do.", "Leonardo da Vinci"));
    quotes.push(new Quote("The only way to do great work is to love what you do.", "Steve Jobs"));
    quotes.push(new Quote("You take your life in your own hands, and what happens? A terrible thing, no one to blame.", " Erica Jong"));
    quotes.push(new Quote("A person who never made a mistake never tried anything new.", "Albert Einstein"));
    const selectedQuote = Math.floor(Math.random() * (quotes.length - 1)); 

    $(".fade-in").animate(
      {
        color: `rgb(${color[0]}, ${color[1]}, ${color[2]})`,
        backgroundColor: `rgb(${color[0]}, ${color[1]}, ${color[2]})`        
      }, 
      {
        duration: 1500,
        complete: this.setState({quote: quotes[selectedQuote], color: color})
      }        
    );
  }
}

class Quote {
  constructor(phrase, author) {
    this.phrase = phrase;
    this.author = author;
  }
}

export default App;
