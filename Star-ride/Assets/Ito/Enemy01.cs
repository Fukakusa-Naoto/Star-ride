using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    // 敵の状態
    enum STATE
    {
        STATE_NORMAL,   // 通常
        STATE_HIT,      // 吹き飛ばされ状態
        STATE_FALL,     // 落下中
        STATE_DEAD,     // 死亡
    };

    // 敵の状態
    STATE m_state = STATE.STATE_NORMAL;

    // プレイヤーを取得
    GameObject player;
    GameObject enemy;

    // 床との判定用の幅と高さ
    float WIDTH;
    float HEIGHT;

    // オブジェクト同士の判定用の半径
    float RADIUS;

    // 最大移動速度
    float MAX_SPEED;

    // 重さ
    float WEIGHT;

    // 床に対する摩擦係数
    float FRICTION;

    // 思考間隔（単位：秒）
    float THINK_INTERVAL;

    // 思考タイマー
    float m_thinkTimer;

    // 経過時間
    float elapsedTime = 0.0f;

    // 速度
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // 状態によって処理を分岐させる
        switch (this.m_state)
        {
            case STATE.STATE_NORMAL:  // 通常
                State_Normal(elapsedTime);
                break;
            case STATE.STATE_HIT:     // ヒット中
                State_Hit(elapsedTime);
                break;
            case STATE.STATE_FALL:    // 落下中
                State_Fall(elapsedTime);
                break;
            case STATE.STATE_DEAD:    // 死亡
                break;
            default:
                break;
        }

        //// 摩擦により速度を落とす
        //Friction(elapsedTime);

        //// ヒット中は速度制限をかけない
        //if (m_state != STATE_HIT)
        //{
        //    // 最大速度以上にならないよう調整
        //    if (m_v.LengthSquared() > MAX_SPEED * MAX_SPEED)
        //    {
        //        m_v.Normalize();
        //        m_v *= MAX_SPEED;
        //    }
        //}

        //// 位置に速度を足す
        //m_pos += m_v;

        //// 通常状態で床の上でなければ落下する
        //if (m_state == STATE_NORMAL && CheckFloor() == false)
        //{
        //    // 得点を加算
        //    AddScore(SCORE);
        //    // 落ちたので停止させる
        //    m_v = transform.Translate(0,0,0);
        //    // 状態を落下中へ
        //    m_state = STATE_FALL;
        //}

    }
    int GetDir(GameObject player)
    {
        // ターゲットへのベクトルを求める
        Vector3 v = this.player.transform.position - this.enemy.transform.position;

        //// 内積を使い一番近い角度を求める
        //Matrix rotY = Matrix::CreateRotationY(XMConvertToRadians(45.0f));
        //Vector3 dirVec = new Vector3(0.0f, 0.0f, -1.0f);
        //int dir = 0;
        //float maxVal = dirVec.Dot(v, v);
        //// 内積が一番大きい方向が近い
        //for (int i = 0; i < 7; i++)
        //{
        //    dirVec = Vector3::Transform(dirVec, rotY);
        //    float val = dirVec.Dot(v);          
        //    if (val > maxVal)
        //    {
        //        dir = i + 1;
        //        maxVal = val;
        //    }
        //}

        
        return 0;// dir;
    }

    void State_Normal(float elapsedTime)
    {
        
        //// 定期的に向きを変える
        //m_thinkTimer += elapsedTime;
        //if (m_thinkTimer >= THINK_INTERVAL)
        //{
        //    m_thinkTimer = 0.0f;

        //    // ランダムで移動方向を設定
        //    m_dir = rand() % 8;

        //    // ターゲット方向に向ける
        //    if (target)
        //    {
        //        m_dir = GetDir(target);
        //    }
        //}

        //// 力を加える
        //AddForce(GameWindow::DIR_ANGLE[m_dir], 0.03f);

        //// 落ちそうなら向きと速度を反転する
        //Vector3 tmp = m_pos;
        //m_pos += m_v;
        //if (CheckFloor() == false)
        //{
        //    Matrix rotY = Matrix::CreateRotationY(XMConvertToRadians(180.0f));
        //    m_v = Vector3::Transform(m_v, rotY);
        //    m_dir = (m_dir + 4) % 8;
        //}
        //m_pos = tmp;
    }

    void State_Hit(float elapsedTime)
    {
        // 摩擦により停止したら
        if (vec == new Vector3(0.0f, 0.0f, 0.0f)) 
        {
            m_state = STATE.STATE_NORMAL;
        }
    }

    void State_Fall(float elapsedTime)
    {
        // 下に落ちる
        this.enemy.transform.position += new Vector3(0.0f, -1.0f, 0.0f);

        // ある程度落下したら
        if (this.enemy.transform.position.y < 0)
        {
            m_state = STATE.STATE_DEAD;
           
        }
    }
    
    void Reset()
    {
        //// 停止させ位置と向きをリセットする
        //SetActive(false);
        //m_dir = 0;
        //m_pos = Vector3((float)m_x, 0.0f, (float)m_y);
        //m_thinkTimer = THINK_INTERVAL;

        // 落下中の場合は死亡扱いにする
        if (m_state == STATE.STATE_FALL)
        {
            // 死亡
            m_state = STATE.STATE_DEAD;
            // 表示（OFF）
            this.enemy.SetActive(false);
        }
    }



}
