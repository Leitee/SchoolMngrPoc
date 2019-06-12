import { NgModule } from '@angular/core';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, 
    MatButtonModule, 
    MatSidenavModule, 
    MatIconModule, 
    MatListModule, 
    MatMenuModule, 
    MatGridListModule, 
    MatCardModule, 
    MatExpansionModule, 
    MatFormFieldModule, 
    MatInputModule,
    MatCheckboxModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatButtonToggleModule,
    MatAutocompleteModule,
    MatStepperModule,
    MatTabsModule
} from '@angular/material';

@NgModule({
    imports: [
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatGridListModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatButtonToggleModule,
        MatAutocompleteModule,
        MatStepperModule,
        MatTabsModule
    ],
    exports: [
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatGridListModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatButtonToggleModule,
        MatAutocompleteModule,
        MatStepperModule,
        MatTabsModule
    ]
})
export class MaterialModule { }