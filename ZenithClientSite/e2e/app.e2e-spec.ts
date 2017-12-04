import { Ng2ZenithPage } from './app.po';

describe('ng2-zenith App', function() {
  let page: Ng2ZenithPage;

  beforeEach(() => {
    page = new Ng2ZenithPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
