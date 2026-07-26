import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DirectorComponent } from './director.component';

describe('DirectorComponent', () => {
  let component: DirectorComponent;
  let fixture: ComponentFixture<DirectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DirectorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DirectorComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
