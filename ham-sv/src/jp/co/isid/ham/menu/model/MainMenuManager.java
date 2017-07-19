package jp.co.isid.ham.menu.model;



import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj31InformationCondition;
import jp.co.isid.ham.common.model.Mbj31InformationDAO;
import jp.co.isid.ham.common.model.Mbj31InformationDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * ���C�����j���[�\�������Ǘ�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class MainMenuManager {

    /** �V���O���g���C���X�^���X */
    private static MainMenuManager _manager = new MainMenuManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private MainMenuManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static MainMenuManager getInstance() {
        return _manager;
    }

    /**
     * ���C�����j���[�̕\�������擾���܂�
     * @param cond ����
     * @return ���C�����j���[�̕\�����
     * @throws HAMException
     */
    public FindMainMenuResult findMainMenu(FindMainMenuCondition cond) throws HAMException {

        // ��������
        FindMainMenuResult result = new FindMainMenuResult();

        // �@�\����Info�̎擾
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamID());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // ��ʍ��ڕ\���񐧌�}�X�^�擾
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // �C���t�H���[�V�����}�X�^�擾
        Mbj31InformationDAO infodao = Mbj31InformationDAOFactory.createMbj31InformationDAO();
        Mbj31InformationCondition mbj31cond = new Mbj31InformationCondition();
        mbj31cond.setDispsts("1");
        result.setInfo(infodao.selectVO(mbj31cond));

        // ���O�C�����[�U�[�擾
        LoginDAO logindao = FindMainMenuDAOFactory.createLoginDAO();
        result.setLogin(logindao.selectVO());

        // CR�����Ǘ�(��No������)�擾(���͒S����=����)
        UserCrCreateDataDAO userdao = FindMainMenuDAOFactory.createUserCrCreateDataDAO();
        cond.setInputIntNm(cond.getLastName() + cond.getFirstName());
        result.setNoInputOrderNo(userdao.selectNoInputOrderNo(cond));

        // �d�ʎԎ�R�[�h[�S��](�A���[�g�\������)�擾
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype("25");
        List<Mbj12CodeVO> codeVoList = codedao.selectVO(codecond);
        if (codeVoList != null && codeVoList.size() > 0) {
            cond.setDCarCdAll(codeVoList.get(0).getKEYCODE());
        }
        else {
            cond.setDCarCdAll(" ");
        }


        // ******************************************************
        // (CR������)�Z�L�����e�B���擾
        // ******************************************************
        SecurityInfoManager secManager = SecurityInfoManager.getInstance();
        SecurityInfoCondition secCond = new SecurityInfoCondition();
        List<SecurityInfoVO> secVolist = new ArrayList<SecurityInfoVO>();
        secCond.setHamid(cond.getHamID());
        secCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        secCond.setSecuritycd("S000000104");
        secCond.setUsertype(cond.getUsertype());
        secVolist = secManager.getSecurityInfo(secCond).getSecurityInfo();
        for (SecurityInfoVO securityInfoVO : secVolist) {
            if (securityInfoVO.getCHECK().equals("1")) {
                // �m�F�@�\���L���Ȃ�CR�����Ǘ�(�ύX�f�[�^)�擾

                //AM�ǂƂ��đ��삵�Ă��邩�𔻒肵��Condtion�Ɍ��ʂ��Z�b�g
                codecond = new Mbj12CodeCondition();
                codecond.setCodetype("24");
                List<Mbj12CodeVO> amKykSikCdList = codedao.selectVO(codecond);
                boolean isAm = false;
                //TODO:���������Ȃ��̂łƂ肠����Loop�����Ĕ���
                for (Mbj12CodeVO mbj12CodeVO : amKykSikCdList) {
                    if (mbj12CodeVO.getYOBI1().equals(cond.getKksikognzuntcd()))
                    {
                        if (mbj12CodeVO.getYOBI2().equals("1")) {
                            isAm = true;
                        }
                        break;
                    }
                }
                cond.setIsAmKyk(isAm);

                // CR�����Ǘ�(�ύX�f�[�^)�擾
                result.setUpdatedCr(userdao.selectUpdatedCr(cond));
                break;
            }
        }
//
//        // CR�����Ǘ�(�ύX�f�[�^)�擾
//        result.setUpdatedCr(userdao.selectUpdatedCr(cond));

        return result;
    }

}
