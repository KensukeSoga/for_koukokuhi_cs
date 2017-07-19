package jp.co.isid.ham.login.model;

import java.io.StringReader;
import java.util.List;
import java.util.Map;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.common.model.Tbj35KnrCondition;
import jp.co.isid.ham.common.model.Tbj35KnrDAO;
import jp.co.isid.ham.common.model.Tbj35KnrDAOFactory;
import jp.co.isid.ham.common.model.Tbj35KnrVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.security.SecurityInfo;
import jp.co.isid.nj.security.impl.base.BaseUserInfo;
import jp.co.isid.njsecurity.webservice.stateless.GetSecurityRoleListParameter;
import jp.co.isid.njsecurity.webservice.stateless.GetSecurityRoleListResult;
import jp.co.isid.njsecurity.webservice.stateless.LoginParameter;
import jp.co.isid.njsecurity.webservice.stateless.LoginResult;
import jp.co.isid.njsecurity.webservice.stateless.NJSecurityStatelessService;
import jp.co.isid.njsecurity.webservice.stateless.SecurityInfoUtil;

import org.w3c.dom.CharacterData;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

/**
 * <P>
 * �Ɩ���v�Z�L�����e�B���[���擾Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/05/17 JSE K.Tamura)<BR>
 * </P>
 *
 * @author JSE K.Tamura
 */
public class MprKengenCheckManager {

    /** �J�e�S���[�F���Ό��� */
    private static final String CATEGORY_RELATIVE_AUTHORITY = "201";

    /** �V���O���g���C���X�^���X */
    private static MprKengenCheckManager _manager = new MprKengenCheckManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private MprKengenCheckManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static MprKengenCheckManager getInstance() {
        return _manager;
    }

    /**
     * �Ɩ���v�Z�L�����e�B���[���i���Ό����j�̎擾
     *
     * @param cond ��������
     * @return �Ɩ���v�Z�L�����e�B���[���i���Ό����j
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    public String getAccountSecurityRole(AccountSecurityRoleCondition cond) throws HAMException {

        // ���O�C�����̒[�������擾
        SecurityInfo securityInfo = SecurityInfoUtil.deserialize(cond.getSecurityInfo());
        BaseUserInfo userInfo = (BaseUserInfo) securityInfo.getUserInfo();
        Map loginItemMap = userInfo.getLoginItems();

        // �Ɩ���v�̃f�B���N�g�����擾
        LoginParameter loginParameter = new LoginParameter();
        loginParameter.setAppId(cond.getAplId());
        loginParameter.setBrowser((String) loginItemMap.get("Browser"));
        loginParameter.setId(cond.getEsqId());
        loginParameter.setIpAddress((String) loginItemMap.get("IPAddr"));
        loginParameter.setOs((String) loginItemMap.get("OS"));
        loginParameter.setPass(cond.getPassword());
        loginParameter.setTerminalKind((String) loginItemMap.get("TerminalKind"));

        // �Ɩ���v�̃f�B���N�g�����擾
        NJSecurityStatelessService service = new NJSecurityStatelessService();
        LoginResult loginResult = service.login(loginParameter);

        // �Ɩ���v�̃��[�����擾
        GetSecurityRoleListParameter securityRoleListParameter = new GetSecurityRoleListParameter();
        securityRoleListParameter.setCategory(CATEGORY_RELATIVE_AUTHORITY);
        securityRoleListParameter.setSecurityInfo(loginResult.getSecurityInfo());
        GetSecurityRoleListResult securityRoleListResult = service.getSecurityRoleList(securityRoleListParameter);

        // �Ɩ���v�Z�L�����e�B���[���i���Ό����j��ԋp
        return getRelativeAuthority(securityRoleListResult.getResultXml());

    }

    /**
     * ���Ό����̎擾
     *
     * @param xmlRecords XML���
     * @return ���Ό���
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    private String getRelativeAuthority(String xmlRecords) throws HAMException {

        String relativeAuthority = null;

        try {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            InputSource is = new InputSource();
            is.setCharacterStream(new StringReader(xmlRecords));

            Document doc = db.parse(is);
            NodeList firstNode = doc.getElementsByTagName("SecurityRoleList");
            Element firstNodeElement = (Element) firstNode.item(0);
            NodeList secondNode = firstNodeElement.getElementsByTagName("SecurityRole");
            Element secondNodeElement = (Element) secondNode.item(0);
            NodeList name = secondNodeElement.getElementsByTagName("RoleData");
            Element line = (Element) name.item(0);
            relativeAuthority = getCharacterDataFromElement(line);

            return relativeAuthority;

            // return "31";
        } catch (Exception e) {
            // throw new HAMException("�Z�L�����e�B�f�[�^�擾�G���[", "HF-W0001");
            // �V���ǃ��[�U�[�̑Ή��̂��߁Anull��Ԃ��悤�ɕύX
            return null;
        }

    }

    /**
     * �Ώۗv�f�擾
     *
     * @param xmlRecords XML���
     * @return ���Ό���
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    private static String getCharacterDataFromElement(Element e) throws HAMException {

        Node child = e.getFirstChild();
        if (child instanceof CharacterData) {
            CharacterData cd = (CharacterData) child;
            return StringUtil.trim(cd.getData());
        }
        else {
            throw new HAMException("�Z�L�����e�B�f�[�^�擾�G���[", "HF-W0001");
        }
    }

    // /**
    // * �Ǘ��҃��[�U�[���̎擾
    // *
    // * @param cond ��������
    // * @return �Ǘ��҃��[�U�[���
    // * @throws HAMException �������ɃG���[�����������ꍇ
    // */
    // public Mhf31TntVO findKanriUserInfo(AccountSecurityRoleCondition cond) throws HAMException {
    //
    // KanriUserInfoDAO dao = KanriUserInfoDAOFactory.createKanriUserInfoDAO();
    //
    // List<Mhf31TntVO> list = dao.getKanriUserInfo(cond);
    //
    // // �f�[�^��0���̏ꍇ
    // if (list.size() == 0) {
    // return null;
    // }
    //
    // return list.get(0);
    //
    // }

    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================

    /** ���Ό����F������ */
    private static final String RELATIVE_AUTHORITY_BU = "7";

    /** ���Ό����F�ǌ��� */
    private static final String RELATIVE_AUTHORITY_KYOKU = "31";

    /** �K�w�R�[�h�F�Ǐ��� */
    private static final String KAISO_CD_KYOKUSHOZOKU = "40";

    /** �K�w�R�[�h�F������ */
    private static final String KAISO_CD_BUSHOZOKU = "60";

    /** �M�p�R�[�h�F�ΏۊO */
    private static final String[] SINCD_NOT_SUBJECT = { "7", "8", "9", "A", "X" };

    public MprKengenCheckResult execute(MprKengenCheckCondition cond) throws HAMException {

        MprKengenCheckResult result = new MprKengenCheckResult();

        // �c�Ɠ�
        String eigyobi = "";
        // AM�ǋǃR�[�h
        String kyokuCd = "";
        // �c�Ə��R�[�h
        String egsCd = "";
        // ���Ӑ��ƃR�[�h
        String thsKgyCd = "";
        // ���Ӑ敔��SEQ
        String thsBmnSeq = "";
        // ���Ό���
        String relativeAuthority = "";
        // �^�pNo
        String operationCd = "";
        // �S���҃R�[�h
        String tantoCd = "";

        // �p�����[�^����ڑ�
        eigyobi = cond.getEigyobi();
        operationCd = cond.getOperationNo();
        tantoCd = cond.getTantoCd();

        // ***********************************
        // ���Ό����擾
        // ***********************************
        AccountSecurityRoleCondition accountSecRoleCond = new AccountSecurityRoleCondition();
        accountSecRoleCond.setAplId(cond.getAplId());
        accountSecRoleCond.setEsqId(cond.getEsqId());
        accountSecRoleCond.setPassword(cond.getPassword());
        accountSecRoleCond.setSecurityInfo(cond.getSecurityInfo());
        relativeAuthority = getAccountSecurityRole(accountSecRoleCond);

        // ***********************************
        // �c�Ə��R�[�h�擾
        // ***********************************
        RepaVbjaMeu07SikKrSprdDAO sikKrSprdDao = RepaVbjaMeu07SikKrSprdDAOFactory.createRepaVbjaMeu07SikKrSprdDAO();
        RepaVbjaMeu07SikKrSprdVO sikKrSprdCond = new RepaVbjaMeu07SikKrSprdVO();
        sikKrSprdCond.setSIKCD(operationCd);
        sikKrSprdCond.setSTARTYMD(eigyobi);
        sikKrSprdCond.setENDYMD(eigyobi);
        List<RepaVbjaMeu07SikKrSprdVO> sikKrSprdVoList = sikKrSprdDao.selectVoByDate(sikKrSprdCond);
        if (sikKrSprdVoList.size() > 0) {
            egsCd = sikKrSprdVoList.get(0).getEGSYOCD();
        }

        if (StringUtil.isBlank(relativeAuthority)) {
            //���[���̎擾���ł��Ȃ���΂��̎��_��NG
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }

        // ***********************************
        // �V�X�e���Ǘ����擾(�c�Ɠ��擾)
        // ***********************************
        Tbj35KnrDAO knrDao = Tbj35KnrDAOFactory.createTbj35KnrDAO();
        Tbj35KnrCondition knrCond = new Tbj35KnrCondition();
        knrCond.setSystemno("02");
        List<Tbj35KnrVO> knrVoList = knrDao.selectVO(knrCond);

        if (knrVoList.size() != 1) {
            //throw new HAMException("�V�X�e���Ǘ����擾�G���[", "BJ-E0003");
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }
        eigyobi = knrVoList.get(0).getEIGYOBI();

        // ***********************************
        // ���O�C���ǂ�����Ώۂ̋ǂ��𔻒�
        // ***********************************
        // �R�[�h�}�X�^���擾(�ǃR�[�h)
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("04");
        codeCond.setKeycode("KYOKUCODE");
        List<Mbj12CodeVO> codeVoList = codeDao.selectVO(codeCond);
        if (codeVoList.size() > 0) {
            kyokuCd = codeVoList.get(0).getCODENAME();
        }
        if (!kyokuCd.equals(cond.getKyokuCd())) {
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(true);
            return result;
        }

        // ***********************************
        // �S���҂̏����g�D�Ɠ��Ӑ�R�[�h�œ��Ӑ�S���}�X�^���������ĒS���`�F�b�N���s��
        // ***********************************
        // ��ƃR�[�h�擾
        codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("04");
        codeCond.setKeycode("HONDA");
        codeVoList = codeDao.selectVO(codeCond);
        if (codeVoList.size() > 0) {
            thsKgyCd = codeVoList.get(0).getCODENAME();
        }
        // SEQNO�擾
        codeCond.setCodetype("04");
        codeCond.setKeycode("SEQNO");
        codeVoList = codeDao.selectVO(codeCond);
        if (codeVoList.size() > 0) {
            thsBmnSeq = codeVoList.get(0).getCODENAME();
        }

        // ***********************************
        // �S���҃`�F�b�N
        // ***********************************
        // �E�ʃO���[�v���擾
        String sGrpCd = getSyokuiGrpCd(cond.getEsqId(), eigyobi);

        // �g�D�E�K�w���̎擾
        EigyosyoInfoVO sikKaisoVO = getSikKaisoInfoVO(operationCd, eigyobi);// TODO:�^�pNo
        if (sikKaisoVO == null) {
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }

        // ���Ӑ���擾
        TksInfoCondition tksCond = new TksInfoCondition();
        // tksCond.setEigyobi(eigyobi);
        // tksCond.setEgsCd(egsCd);
        // tksCond.setSikInfo(sikInfo.getSoshikiInfo());
        // tksCond.setSikCond(sikInfo.getSqlConditionOfSoshiki());
        // tksCond.setKokaiTokuisakiInfo(kTI_list);
        tksCond.setTksKgyCd(thsKgyCd);
        tksCond.setTksBmnSeqNo(thsBmnSeq);
        tksCond.setSikcd(operationCd);
        tksCond.setEgsCd(egsCd);
        tksCond.setEigyobi(eigyobi);
        TksInfoVO tksVo = getTksInfo(tksCond);
        if (tksVo == null) {
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }

        // �`�F�b�N�p�g�D�R�[�h
        String organizaitonCodeForCheck = null;

        // �ǌ����̏ꍇ
        if (RELATIVE_AUTHORITY_KYOKU.equals(relativeAuthority)) {

            // �������̏ꍇ
            if (KAISO_CD_BUSHOZOKU.equals(sikKaisoVO.getKaisoCd())) {

                // ��ʑg�D���i�ǁj�̎擾
                sikKrSprdCond = new RepaVbjaMeu07SikKrSprdVO();
                sikKrSprdCond.setKRIJSIKCD(sikKaisoVO.getJSikCd());
                sikKrSprdCond.setEGSYOCD(egsCd);
                sikKrSprdCond.setSTARTYMD(eigyobi);
                sikKrSprdCond.setENDYMD(eigyobi);
                RepaVbjaMeu07SikKrSprdVO jSikInfo = getJSoshikiInfo(sikKrSprdCond);
                if (jSikInfo == null) {
                    result.setRelativeAuthority(relativeAuthority);
                    result.setEgsCd(egsCd);
                    result.setCheckResult(false);
                    return result;
                }

                // �`�F�b�N�p�g�D�R�[�h�ɏ�ʑg�D�R�[�h�i�ǁj��ݒ�
                organizaitonCodeForCheck = jSikInfo.getSIKCDKYK();

                // ���Ӑ���̋Ǖ\�����i�����j���A��ʑg�D���i�ǁj�̂��̂ɏ㏑��
                // for (int i = 0; i< tks_list.size(); i++) {
                // tks_list.get(i).setKykHyojiKj(jSikInfo.getKykHyojiKj());
                // ModelUtils.copyMemberSearchAfterInstace(tks_list.get(i));
                // }
            }
            // �Ǐ����̏ꍇ
            else if (KAISO_CD_KYOKUSHOZOKU.equals(sikKaisoVO.getKaisoCd())) {

                // �`�F�b�N�p�g�D�R�[�h�ɉ^�pNo.��ݒ�
                organizaitonCodeForCheck = operationCd;
            }
        }
        // �������̏ꍇ
        else if (RELATIVE_AUTHORITY_BU.equals(relativeAuthority)) {
            // �`�F�b�N�p�g�D�R�[�h�ɉ^�pNo.��ݒ�
            organizaitonCodeForCheck = operationCd;
        }

        // ���J�͈́^���j�b�gNo.�}�X�^���i�[�ϐ�
        KhUnMstVO kUnitMstVO;
        // ���[�v�̓x��null�������A����������
        kUnitMstVO = null;

        boolean chkres = false;
        // �������̏ꍇ
        if (RELATIVE_AUTHORITY_BU.equals(relativeAuthority)) {

            // �S���ґg�D�`�F�b�N�i���j
            if (organizaitonCodeForCheck.equals(tksVo.getSIKCDBU())) {

                // �M�p�R�[�h�`�F�b�N
                if (checkSinCd(tksVo.getSINCD())) {
                    chkres = true;
                }
                else {
                    chkres = false;
                }
            } else {
                // ���J�͈́^���j�b�gNo.�}�X�^���擾
                KhUnMstCondition kkhCond = new KhUnMstCondition();
                kkhCond.setJSikCd(sikKaisoVO.getJSikCd());// ��ʑg�D�R�[�h
                kkhCond.setOperationNo(operationCd);// �����g�D�R�[�h�͉^�pNo.
                kkhCond.setSyokuiGrpCd(sGrpCd);// �E�ʓ����O���[�v
                kkhCond.setTntCd("'" + tantoCd + "', '*'");
                kkhCond.setEigyobi(eigyobi);

                kkhCond.setTksCd(tksVo.getTHSKGYCD() + tksVo.getSEQNO() + tksVo.getTRTNTSEQNO());// ���Ӑ�R�[�h�i10���j
                kkhCond.setTermBegin(DateUtil.getTermBegin(eigyobi));
                kkhCond.setTermEnd(DateUtil.getTermEnd(eigyobi));
                // kUnitMstVO = getKhUnMstInfo(sikKaisoVO, sGI_result, tks_list.get(i));
                kUnitMstVO = getKhUnMstInfo(kkhCond);
                if (kUnitMstVO == null) {
                    chkres = false;
                }
                else {
                    // �M�p�R�[�h�`�F�b�N
                    if (checkSinCd(tksVo.getSINCD())) {
                        chkres = true;
                    }
                    else {
                        chkres = false;
                    }
                }
            }
        }
        // �ǌ����̏ꍇ
        else if (RELATIVE_AUTHORITY_KYOKU.equals(relativeAuthority)) {

            // �S���ґg�D�`�F�b�N�i�ǁj
            if (organizaitonCodeForCheck.equals(tksVo.getSIKCDKYK())) {

                // �M�p�R�[�h�`�F�b�N
                if (checkSinCd(tksVo.getSINCD())) {
                    // // ���Ӑ��񂩂瓾�Ӑ惊�X�g��ݒ�
                    // setTksListForTksInfo(tksVo);
                    chkres = true;
                } else {
                    // _errorInfo = setErrorInfo("�M�p�R�[�h�`�F�b�N�G���[", "HF-W0012");
                    chkres = false;
                }
            } else {
                // ���J�͈́^���j�b�gNo.�}�X�^���擾
                KhUnMstCondition kkhCond = new KhUnMstCondition();
                kkhCond.setJSikCd(sikKaisoVO.getJSikCd());// ��ʑg�D�R�[�h
                kkhCond.setOperationNo(operationCd);// �����g�D�R�[�h�͉^�pNo.
                kkhCond.setSyokuiGrpCd(sGrpCd);// �E�ʓ����O���[�v
                kkhCond.setTntCd("'" + tantoCd + "', '*'");
                kkhCond.setEigyobi(eigyobi);

                kkhCond.setTksCd(tksVo.getTHSKGYCD() + tksVo.getSEQNO() + tksVo.getTRTNTSEQNO());// ���Ӑ�R�[�h�i10���j
                kkhCond.setTermBegin(DateUtil.getTermBegin(eigyobi));
                kkhCond.setTermEnd(DateUtil.getTermEnd(eigyobi));
                // kUnitMstVO = getKhUnMstInfo(sikKaisoVO, sGI_result, tks_list.get(i));
                kUnitMstVO = getKhUnMstInfo(kkhCond);
                if (kUnitMstVO == null) {
                    chkres = false;
                }
                else {
                    // �M�p�R�[�h�`�F�b�N
                    if (checkSinCd(tksVo.getSINCD())) {
                        chkres = true;
                    }
                    else {
                        chkres = false;
                    }
                }
            }

        } else if (relativeAuthority == null || relativeAuthority.trim().length() == 0) {

            chkres = false;

        } else {
            // ���̑��̌����̏ꍇ

            // ���J�͈́^���j�b�gNo.�}�X�^���擾
            KhUnMstCondition kkhCond = new KhUnMstCondition();
            kkhCond.setJSikCd(sikKaisoVO.getJSikCd());// ��ʑg�D�R�[�h
            kkhCond.setOperationNo(operationCd);// �����g�D�R�[�h�͉^�pNo.
            kkhCond.setSyokuiGrpCd(sGrpCd);// �E�ʓ����O���[�v
            kkhCond.setTntCd("'" + tantoCd + "', '*'");
            kkhCond.setEigyobi(eigyobi);

            kkhCond.setTksCd(tksVo.getTHSKGYCD() + tksVo.getSEQNO() + tksVo.getTRTNTSEQNO());// ���Ӑ�R�[�h�i10���j
            kkhCond.setTermBegin(DateUtil.getTermBegin(eigyobi));
            kkhCond.setTermEnd(DateUtil.getTermEnd(eigyobi));
            kUnitMstVO = getKhUnMstInfo(kkhCond);
            if (kUnitMstVO == null) {
                chkres = false;
            }
            else {
                // �M�p�R�[�h�`�F�b�N
                if (checkSinCd(tksVo.getSINCD())) {
                    chkres = true;
                }
                else {
                    chkres = false;
                }
            }
        }

        // // ���J�͈́^���j�b�gNo.�}�X�^���f�[�^�Ȃ�
        // if (kUnitMstVO == null) {
        // chkres = false;
        // }
        // // �M�p�R�[�h�`�F�b�N
        // if (checkSinCd(tksVo.getSINCD())) {
        // chkres = true;
        // }
        // else {
        // chkres = false;
        // }

        result.setRelativeAuthority(relativeAuthority);
        result.setEgsCd(egsCd);
        result.setCheckResult(chkres);
        return result;
    }

    /**
     * �E�ʓ����O���[�v�R�[�h�̎擾���������s���܂�
     *
     * @return �E�ʓ����O���[�v�R�[�h
     * @throws CNPException �����Ɏ��s�����ꍇ
     */
    public String getSyokuiGrpCd(String esqId, String eigyobi) throws HAMException {
        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        SyokuiGrpInfoCondition cond = new SyokuiGrpInfoCondition();
        cond.setEsqId(esqId);
        cond.setEigyobi(eigyobi);
        List<SyokuiGrpInfoVO> voList = dao.getSyokuiGrpInfo(cond);

        String groupJonCd;
        if (voList.size() == 0) {
            // �ЊO�҂̏ꍇ�A�E�ʓ����R�[�h�Ȃ�
            groupJonCd = "'*'";
        }
        else {
            StringBuffer grpCd = new StringBuffer();
            for (int i = 0; i < voList.size(); i++) {
                grpCd.append("'" + voList.get(i).getGrpCd() + "',");
            }
            grpCd.append("'*'");
            groupJonCd = grpCd.toString();
        }
        return groupJonCd;
    }

    /**
     * �����������g�p���A�g�D�K�w���̎擾���������s���܂�
     *
     * @return �g�D�K�w���VO
     * @throws CNPException �����Ɏ��s�����ꍇ
     */
    public EigyosyoInfoVO getSikKaisoInfoVO(String tntSikCd, String eigyobi) throws HAMException {
        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        EigyosyoInfoCondition cond = new EigyosyoInfoCondition();
        cond.setTntSikCd(tntSikCd);// �S���ґg�D�R�[�h�͉^�pNo.
        cond.setEigyobi(eigyobi);
        List<EigyosyoInfoVO> voList = dao.getEigyosyoInfo(cond);

        // �f�[�^��0���̏ꍇ
        if (voList.size() == 0) {
            //throw new HAMException("�g�D�K�w���擾�G���[", "HF-W0010");
            return null;
        }
        return voList.get(0);
    }

    /**
     * �g�D���ƌ��J���Ӑ�����g�p���A���Ӑ���i���Ӑ惊�X�g�\���p�j�擾���������s���܂�
     *
     * @param sikInfo �g�D���
     * @param kTI_List ���J���Ӑ���
     * @return ���Ӑ���i���Ӑ惊�X�g�\���p�jVO���X�g
     * @throws CNPException �����Ɏ��s�����ꍇ
     */
    public TksInfoVO getTksInfo(TksInfoCondition cond) throws HAMException {
        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        List<TksInfoVO> voList = dao.getTksInfo(cond);

        // �f�[�^��0���̏ꍇ
        if (voList.size() == 0) {
            //throw new HAMException("���Ӑ���擾", "HF-W0009");
            return null;
        }
        return voList.get(0);
    }

    /**
     * �����������g�p���A��ʑg�D�R�[�h(��)�̎擾���������s���܂�
     *
     * @return ��ʑg�D�R�[�h(��)
     * @param �g�D�K�w���
     * @param �l���
     * @throws CNPException �����Ɏ��s�����ꍇ
     */
    public RepaVbjaMeu07SikKrSprdVO getJSoshikiInfo(RepaVbjaMeu07SikKrSprdVO cond) throws HAMException {
        RepaVbjaMeu07SikKrSprdDAO dao = RepaVbjaMeu07SikKrSprdDAOFactory.createRepaVbjaMeu07SikKrSprdDAO();
        List<RepaVbjaMeu07SikKrSprdVO> voList = dao.selectVoByDate(cond);

        // �f�[�^���Ȃ��ꍇ
        if (voList.size() == 0) {
            //throw new HAMException("��ʑg�D�R�[�h(��)�擾�G���[", "HF-W0011");
            return null;
        }
        return voList.get(0);
    }

    /**
     * �M�p�R�[�h�`�F�b�N
     *
     * @param sinCd �M�p�R�[�h
     * @return true�FOK�Afalse�FNG
     */
    private boolean checkSinCd(String sinCd) {
        String subjectCode = sinCd.substring(0, 1);
        for (int i = 0; i < SINCD_NOT_SUBJECT.length; i++) {
            if (SINCD_NOT_SUBJECT[i].equals(subjectCode)) {
                return false;
            }
        }
        return true;
    }

    /**
     * �����������g�p���A���J�͈�/���j�b�gNo.�}�X�^���̎擾���������s���܂�
     *
     * @param sikKaisoVO �g�D�E�K�w���VO
     * @param sGI_result �E�ʓ����O���[�v�擾����
     * @param tksInfoVO ���Ӑ���VO
     * @return ���Ӑ���i���Ӑ惊�X�g�\���p�jVO���X�g
     * @throws CNPException �����Ɏ��s�����ꍇ
     */
    public KhUnMstVO getKhUnMstInfo(KhUnMstCondition cond) throws HAMException {

        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        List<KhUnMstVO> list = dao.getKhUnMstInfo(cond);
        // �f�[�^��0���̏ꍇ
        if (list.size() == 0) {
            return null;
        }

        return list.get(0);
    }
}
