import React from 'react';
import './App.css';

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      quote: new Quote(),
      color: ''
    }
    this.newQuoteAndColor = this.newQuoteAndColor.bind(this);
  }

  componentDidMount() {    
    this.newQuoteAndColor();
  }

  render() {
    const twitterLink = ``;
    const tumblerLink = ``;

    const transitionProperties = "all 2s ease";
    const fadeColorText = { color: this.state.color, transition: transitionProperties };
    const fadeColorBackground = { color: "white", backgroundColor: this.state.color, transition: transitionProperties };
    
    return (      
      <div id="page" className="container-fluid row align-items-center" style={fadeColorBackground}>
        <div id="quote-box" className="container-sm col-4 rounded-2">
          <p id="text" style={fadeColorText}>
            <i className="fa fa-quote-left quote-icon"></i>
            {this.state.quote.phrase}
            <i className="fa fa-quote-right quote-icon"></i>
          </p>
          <p id="author" style={fadeColorText}>- {this.state.quote.author}</p>
          <div className="buttons row gap-2">
            <a href={twitterLink} id="tweet-quote" target="_blank" className="btn btn-default col-1 rounded-1" style={fadeColorBackground}>
              <i className="fa fa-twitter"></i>
            </a>
            <a href={tumblerLink}  id="tumblr-quote" target="_blank" className="btn btn-default col-1 rounded-1" style={fadeColorBackground}>
              <i className="fa fa-tumblr"></i>
            </a>
            <button id="new-quote" className="btn btn-default col-auto ms-auto rounded-1" style={fadeColorBackground} onClick={this.newQuoteAndColor}>
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
    const newColor = `rgb(${r}, ${g}, ${b})`;
  
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
    const newQuoteIndex = Math.floor(Math.random() * (quotes.length - 1)); 

    this.setState({quote: quotes[newQuoteIndex], color: newColor});
  }
}

class Quote {
  constructor(phrase, author) {
    this.phrase = phrase;
    this.author = author;
  }
}

export default App;
