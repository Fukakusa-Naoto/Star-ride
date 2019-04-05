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

    // 点数
    int SCORE;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //// アクティブフラグがfalseの場合は何もしない
        //if (!m_activeFlag) return true;

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


    void State_Normal(float elapsedTime)
    {
        //// プレイヤーを取得
        //Object* target = m_gameWindow->GetStage()->GetPlayer();

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
        //// 摩擦により停止したら
        //if (m_v == Vector3::Zero)
        //{
        //    m_state = STATE_NORMAL;
        //}
    }

    void State_Fall(float elapsedTime)
    {
        //// 下に落ちる
        //m_pos.y -= GameWindow::FALL_SPEED * elapsedTime;

        //// ある程度落下したら
        //if (m_pos.y < -GameWindow::FALL_DISTANCE)
        //{
        //    m_state = STATE_DEAD;
        //    // 表示（OFF）
        //    SetDisplayFlag(false);
        //}
    }

<<<<<<< HEAD
    //void OnHit(Object* object)
    //{
=======
    void OnHit(object o)
    {
>>>>>>> 086abd7ec8517177d9f60879060decd24b1635fb
        //// 思考タイマーを初期化
        //m_thinkTimer = THINK_INTERVAL;
        //// 衝突したのでいったん停止させる
        //m_v = Vector3::Zero;
        //// 衝突した相手へのベクトルを求めて移動方向を算出
        //Vector3 v = object->GetPosition() - this->GetPosition();
        //float angle = atan2f(v.x, v.z);
        //// 相手から受ける力を加える
        //AddForce(angle, object->GetHitForce());
        //// 衝突状態へ
        //m_state = STATE_HIT;
    //}

    void Reset()
    {
        //// 停止させ位置と向きをリセットする
        //SetActive(false);
        //m_dir = 0;
        //m_pos = Vector3((float)m_x, 0.0f, (float)m_y);
        //m_thinkTimer = THINK_INTERVAL;

        //// 落下中の場合は死亡扱いにする
        //if (m_state == STATE_FALL)
        //{
        //    // 死亡
        //    m_state = STATE_DEAD;
        //    // 表示（OFF）
        //    SetDisplayFlag(false);
        //}
    }



}
