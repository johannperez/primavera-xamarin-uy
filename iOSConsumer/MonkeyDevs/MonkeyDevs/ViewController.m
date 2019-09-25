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

MonkeysSDK_MonkeysSDK* sdk;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    sdk = [[MonkeysSDK_MonkeysSDK alloc] init];
    
}

- (IBAction)getRandomMonkeySync:(id)sender {
     NSString* monkey = [sdk getRandomMonkey];
    _resultsUILabel.text = monkey;
}
- (IBAction)getRandomMonkeyAsync:(id)sender {
    dispatch_queue_t queue =dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0);
    
    dispatch_async(queue, ^{
        NSString* monkey = [sdk getRandomMonkey];

        dispatch_async(dispatch_get_main_queue(), ^{
            self->_resultsUILabel.text = monkey;
        });
    });
}

- (IBAction)boom:(id)sender {
    @try {
        [sdk monkeyBomb];
    } @catch (NSException *exception) {
        _resultsUILabel.text = [@"🙉 Something exploded! " stringByAppendingString:exception.reason];
    } @finally {
        
    }
}
- (IBAction)getMonkeys:(id)sender {
    
    dispatch_queue_t queue =dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0);
    
    dispatch_async(queue, ^{
        NSArray<MonkeysSDK_Monkey*> * monkeys = [sdk getMonkeyDevs];

        dispatch_async(dispatch_get_main_queue(), ^{
            NSMutableString* str = [[NSMutableString alloc] init];
            for (MonkeysSDK_Monkey* monkey in monkeys)
            {
                [str appendString:@"  🐵"];
                [str appendString:monkey.name];
            }
            
            self->_resultsUILabel.text = str;
        });
    });
}

@end
