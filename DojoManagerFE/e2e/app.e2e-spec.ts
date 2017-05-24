import { DojoManagerFEPage } from './app.po';

describe('dojo-manager-fe App', () => {
  let page: DojoManagerFEPage;

  beforeEach(() => {
    page = new DojoManagerFEPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
