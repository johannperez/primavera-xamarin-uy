//
//  ViewController.h
//  Monkeydevs
//
//  Created by Johann Perez on 9/24/19.
//  Copyright © 2019 Nareia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <MonkeysSDK/MonkeysSDK.h>

@interface ViewController : UIViewController

@property (weak, nonatomic) IBOutlet UILabel *resultsUILabel;
@property (weak, nonatomic) IBOutlet UIButton *getRandomMonkeySyncUIButton;
@property (weak, nonatomic) IBOutlet UIButton *getRandomMonkeyAsyncUIButton;
@property (weak, nonatomic) IBOutlet UIButton *getMonkeysUIButton;

@end

