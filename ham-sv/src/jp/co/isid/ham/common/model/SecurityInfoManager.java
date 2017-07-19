package jp.co.isid.ham.common.model;

import java.util.List;
import java.util.ArrayList;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * �Z�L�����e�B���Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/11 �X)<BR>
 * </P>
 * @author �X
 */
public class SecurityInfoManager
{
    /** �萔 */
    private String _allKksikognzuntcd = "*******";
    private String _defaultSetting = "0";

    /** �V���O���g���C���X�^���X */
    private static SecurityInfoManager _manager = new SecurityInfoManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private SecurityInfoManager()
    {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static SecurityInfoManager getInstance()
    {
        return _manager;
    }

    /**
     * �Z�L�����e�B���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public SecurityInfoResult getSecurityInfo(SecurityInfoCondition condition) throws HAMException
    {
        SecurityInfoResult result = new SecurityInfoResult();
        SecurityInfoVO vo = new SecurityInfoVO();

        if ((condition != null) &&
           (condition.getHamid() != null) &&
           (condition.getSecuritycd() != null) &&
           (condition.getUsertype() != null) &&
           (condition.getKksikognzuntcd() != null))
        {
            Mbj43SecurityItemDAO mbj43Dao = Mbj43SecurityItemDAOFactory.createMbj43SecurityItemDAO();

            Mbj43SecurityItemCondition mbj43Condition = new Mbj43SecurityItemCondition();
            mbj43Condition.setSecuritycd(condition.getSecuritycd());

            List<Mbj43SecurityItemVO> mbj43List = mbj43Dao.selectVO(mbj43Condition);

            if (mbj43List.size() == 1)
            {
                vo.setHAMID(condition.getHamid());
                vo.setSECURITYCD(condition.getSecuritycd());
                vo.setSECURITYTYPE(mbj43List.get(0).getSECURITYTYPE());
                vo.setSECURITYNM(mbj43List.get(0).getSECURITYNM());
                vo.setCHECK(_defaultSetting);    // �f�t�H���g�̃Z�L�����e�B�͖���
                vo.setUPDATE(_defaultSetting);   // �f�t�H���g�̃Z�L�����e�B�͖���
                vo.setREFERENCE(_defaultSetting);// �f�t�H���g�̃Z�L�����e�B�͖���

                // ���[�U���Z�L�����e�B�ݒ�
                Mbj42SecurityDAO mbj42Dao = Mbj42SecurityDAOFactory.createMbj42SecurityDAO();
                Mbj42SecurityCondition mbj42Condition = new Mbj42SecurityCondition();
                mbj42Condition.setHamid(condition.getHamid());
                mbj42Condition.setSecuritycd(condition.getSecuritycd());
                List<Mbj42SecurityVO> mbj42List = mbj42Dao.selectVO(mbj42Condition);

                if (mbj42List.size() == 1)
                {
                    vo.setCHECK(mbj42List.get(0).getCHECK());
                    vo.setUPDATE(mbj42List.get(0).getUPDATE());
                    vo.setREFERENCE(mbj42List.get(0).getREFERENCE());
                }
                else
                {
                    // �ǃR�[�h�A���[�U��ʖ��Z�L�����e�B�ݒ�
                    Mbj44SecurityBaseDAO mbj44Dao = Mbj44SecurityBaseDAOFactory.createMbj44SecurityBaseDAO();
                    Mbj44SecurityBaseCondition mbj44Condition1 = new Mbj44SecurityBaseCondition();
                    mbj44Condition1.setKksikognzuntcd(condition.getKksikognzuntcd());
                    mbj44Condition1.setUsertype(condition.getUsertype());
                    mbj44Condition1.setSecuritycd(condition.getSecuritycd());
                    List<Mbj44SecurityBaseVO> mbj44List1 = mbj44Dao.selectVO(mbj44Condition1);

                    if (mbj44List1.size() == 1)
                    {
                        vo.setCHECK(mbj44List1.get(0).getCHECK());
                        vo.setUPDATE(mbj44List1.get(0).getUPDATE());
                        vo.setREFERENCE(mbj44List1.get(0).getREFERENCE());
                    }
                    else
                    {
                        // �ǃR�[�h���ʁA���[�U��ʖ��Z�L�����e�B�ݒ�
                        Mbj44SecurityBaseCondition mbj44Condition2 = new Mbj44SecurityBaseCondition();
                        mbj44Condition2.setKksikognzuntcd(_allKksikognzuntcd);
                        mbj44Condition2.setUsertype(condition.getUsertype());
                        mbj44Condition2.setSecuritycd(condition.getSecuritycd());
                        List<Mbj44SecurityBaseVO> mbj44List2 = mbj44Dao.selectVO(mbj44Condition2);

                        if (mbj44List2.size() == 1)
                        {
                            vo.setCHECK(mbj44List2.get(0).getCHECK());
                            vo.setUPDATE(mbj44List2.get(0).getUPDATE());
                            vo.setREFERENCE(mbj44List2.get(0).getREFERENCE());
                        }
                    }
                }

            }
        }

        List<SecurityInfoVO> voList = new ArrayList<SecurityInfoVO>();
        voList.add(vo);
        result.setSecurityInfo(voList);

        return result;

    }

}
