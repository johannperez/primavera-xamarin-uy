//
//  ViewController.m
//  Monkeydevs
//
//  Created by Johann Perez on 9/24/19.
//  Copyright © 2019 Nareia. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    MonkeysSDK_MonkeysSDK* sdk = [[MonkeysSDK_MonkeysSDK alloc] init];
    NSString* monkey = [sdk getRandomMonkey];
    NSArray<MonkeysSDK_Monkey*>* monkeys = [sdk getMonkeyDevs];
    
    @try {
        [sdk monkeyBomb];
    } @catch (NSException *exception) {
        NSLog([exception reason]);
    } @finally {
        
    }
    
}


@end
