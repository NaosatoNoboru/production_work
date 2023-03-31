using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Collar : MonoBehaviour
{
    public Puzzle_Generator Puzzle_Generator;
    public Select Select;
    public int type;//0 = ������z�� 1 = 0 + �� 2 = 0 +�� 3 = 0 + �� 4 = 0 + �E

    private GameObject[] pg_box = new GameObject[25];//�{�b�N�X�̒��g�R�s�[�p
    private int seq_num;                             //�z��ԍ�
    private int old_seq_num;                         //�Â��z��ԍ�

    // Start is called before the first frame update
    void Start()
    {
        old_seq_num = 0;
    }

    // Update is called once per frame
    public void Change_Color()
    {
        seq_num = Select.move_num[0] + Select.move_num[1] * 5;

        ////�ړ�������X�V
        //if (seq_num != old_seq_num ||
        //    gameObject.GetComponent<MeshRenderer>().material != pg_box[seq_num].GetComponent<MeshRenderer>().material)
        //{

        for (int i = 0; i < 25; i++)
        {
            pg_box[i] = Puzzle_Generator.puzzle_box[i];
        }

        //�F�ύX
        switch (type)
        {
            case 0:
                gameObject.GetComponent<MeshRenderer>().material =
                    pg_box[seq_num].GetComponent<MeshRenderer>().material;
                break;
            case 1://��
                if (seq_num - 5 < 0)
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num + (5 * 4)].GetComponent<MeshRenderer>().material;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num - 5].GetComponent<MeshRenderer>().material;
                }
                break;
            case 2://��
                if (seq_num + 5 > 24)
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num - (5 * 4)].GetComponent<MeshRenderer>().material;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num + 5].GetComponent<MeshRenderer>().material;
                }
                break;
            case 3://��
                if (seq_num - 1 == -1 || seq_num - 1 == 4 || seq_num - 1 == 9 ||
                    seq_num - 1 == 14 || seq_num - 1 == 19)
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num + 4].GetComponent<MeshRenderer>().material;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num - 1].GetComponent<MeshRenderer>().material;
                }
                break;
            case 4://�E
                if (seq_num + 1 == 5 || seq_num + 1 == 10 || seq_num + 1 == 15 ||
                    seq_num + 1 == 20 || seq_num + 1 == 25)
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num - 4].GetComponent<MeshRenderer>().material;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material =
                        pg_box[seq_num + 1].GetComponent<MeshRenderer>().material;
                }
                break;
            default:
                break;
        }
        //}

        old_seq_num = seq_num;
    }
}
