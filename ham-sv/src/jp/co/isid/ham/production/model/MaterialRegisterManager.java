package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj05CarDAO;
import jp.co.isid.ham.common.model.Mbj05CarDAOFactory;
import jp.co.isid.ham.common.model.Mbj05CarVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj32DepartmentCondition;
import jp.co.isid.ham.common.model.Mbj32DepartmentDAO;
import jp.co.isid.ham.common.model.Mbj32DepartmentDAOFactory;
import jp.co.isid.ham.common.model.Mbj32DepartmentVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.Mbj38CarConvertDAO;
import jp.co.isid.ham.common.model.Mbj38CarConvertDAOFactory;
import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
import jp.co.isid.ham.common.model.Mbj52SzTntUserCondition;
import jp.co.isid.ham.common.model.Mbj52SzTntUserDAO;
import jp.co.isid.ham.common.model.Mbj52SzTntUserDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj15CmCodeCondition;
import jp.co.isid.ham.common.model.Tbj15CmCodeDAO;
import jp.co.isid.ham.common.model.Tbj15CmCodeDAOFactory;
import jp.co.isid.ham.common.model.Tbj15CmCodeVO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoCondition;
import jp.co.isid.ham.common.model.Tbj16ContractInfoDAO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoDAOFactory;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj17ContentDAO;
import jp.co.isid.ham.common.model.Tbj17ContentDAOFactory;
import jp.co.isid.ham.common.model.Tbj17ContentVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataDAO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataDAOFactory;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj19JasracCondition;
import jp.co.isid.ham.common.model.Tbj19JasracDAO;
import jp.co.isid.ham.common.model.Tbj19JasracDAOFactory;
import jp.co.isid.ham.common.model.Tbj19JasracVO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj24LogContractInfoVO;
import jp.co.isid.ham.common.model.Tbj25LogSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataCondition;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataDAO;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataDAOFactory;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialCondition;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAOFactory;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentDAO;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentDAOFactory;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentVO;
import jp.co.isid.ham.common.model.Tbj41LogTempSozaiKanriDataCondition;
import jp.co.isid.ham.common.model.Tbj41LogTempSozaiKanriDataDAO;
import jp.co.isid.ham.common.model.Tbj41LogTempSozaiKanriDataDAOFactory;
import jp.co.isid.ham.common.model.Tbj41LogTempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnCondition;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnDAO;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnDAOFactory;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnVO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOACondition;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOADAO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOADAOFactory;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;
import jp.co.isid.ham.common.model.Tbj44LogSozaiKanriListCmnDAO;
import jp.co.isid.ham.common.model.Tbj44LogSozaiKanriListCmnDAOFactory;
import jp.co.isid.ham.common.model.Tbj44LogSozaiKanriListCmnVO;
import jp.co.isid.ham.common.model.Tbj45LogSozaiKanriListCmnOAVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.util.ContractMaterialUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * 素材登録Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・マスタ追加対応(2014/10/30 HLC K.Soga)<BR>
 * ・素材登録不具合対応(2015/2/17 HLC K.Soga)<BR>
 * ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
 * ・HDX対応(2016/02/18 HLC K.Soga)<BR>
 * ・HDX不具合対応(2016/05/30 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 *
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialRegisterManager {

    /** シングルトン変数 */
    private static MaterialRegisterManager _manager = new MaterialRegisterManager();

    /** 2015/11/10 JASRAC対応 HLC S.Fujimoto ADD Start */
    //新規採番
    private static final String NEWNO = "0244=XXYYYY";
    /** 2015/11/10 JASRAC対応 HLC S.Fujimoto ADD End */

    private MaterialRegisterManager() {
    }

    /** インスタンスを取得します */
    public static MaterialRegisterManager getInstance() {
        return _manager;
    }

    /**
     * 初期化用に、素材登録一覧及びマスタを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialRegisterResult getInitMaterialRegister(MaterialRegisterCondition cond) throws HAMException {

        //初期設定
        MaterialRegisterResult result = new MaterialRegisterResult();
        MaterialRegisterDAO dao = MaterialRegisterDAOFactory.createFindMaterialListDao();

        //権限取得
        //機能制御Infoの取得
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormid());
        funccond.setFunctype("2");
        funccond.setHamid(cond.getHamid());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        //セキュリティ情報取得
        SecurityInfoManager secManager = SecurityInfoManager.getInstance();
        SecurityInfoCondition secCond = new SecurityInfoCondition();
        List<SecurityInfoVO> secVolist = new ArrayList<SecurityInfoVO>();
        secCond.setHamid(cond.getHamid());
        secCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        secCond.setUsertype(cond.getUsertype());
        for (String securityCd : cond.getFunctionCdList()) {
            secCond.setSecuritycd(securityCd);
            secVolist.addAll(secManager.getSecurityInfo(secCond).getSecurityInfo());
        }
        result.setSecurityInfoVoList(secVolist);

        //コードマスタ取得準備(企業コード、契約種類用)
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANY);
        List<Mbj12CodeVO> codeList = codeDao.selectVO(codeCond);
        codeCond.setCodetype(HAMConstants.CODETYPE_CTRTKBN);
        codeList.addAll(codeDao.selectVO(codeCond));
        result.setCodeList(codeList);

        //車種取得準備
        Mbj05CarDAO carDao = Mbj05CarDAOFactory.createMbj05CarDAO();
        //リスト内の車種マスタを取得
        List<Mbj05CarVO> carVo = carDao.selectVO(new Mbj05CarCondition());
        result.setCarList(carVo);

        //画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO controlDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition displayControlCond = new Mbj37DisplayControlCondition();
        displayControlCond.setFormid(cond.getFormid());
        List<Mbj37DisplayControlVO> displayControlVoList = controlDao.selectVO(displayControlCond);
        result.setMbj37DisplayControlVoList(displayControlVoList);

        //一覧表示パターン取得
        Tbj30DisplayPatternDAO patternDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition displayPatternCond = new Tbj30DisplayPatternCondition();
        displayPatternCond.setHamid(cond.getHamid());
        displayPatternCond.setFormid(cond.getFormid());
        List<Tbj30DisplayPatternVO> displayPatternVoList = patternDao.selectVO(displayPatternCond);
        result.setTbj30DisplayPatternVoList(displayPatternVoList);

        //採番テーブルの取得
        Tbj15CmCodeDAO cmCdDao = Tbj15CmCodeDAOFactory.createTbj15CmCodeDAO();
        List<Tbj15CmCodeVO> cmCdList = cmCdDao.selectVO(new Tbj15CmCodeCondition());
        result.setCmCdList(cmCdList);

        //素材情報の取得
        List<Tbj18SozaiKanriDataVO> materialList = dao.findMaterialListByCondition(cond);
        result.setMaterialList(materialList);

        /** 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
        //仮素材情報の取得
        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj36TempSozaiKanriDataCondition tbj36Cond = new Tbj36TempSozaiKanriDataCondition();
        tbj36Cond.setNokbn(cond.getNoKbn());
        result.setTempMaterialList(tbj36Dao.selectVO(tbj36Cond));

        //割付済み素材を取得
        Tbj38RdProgramMaterialDAO tbj38Dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj38RdProgramMaterialCondition tbj38Cond = new Tbj38RdProgramMaterialCondition();
        result.setRdProgramMaterialList(tbj38Dao.findUsedRdProgramMaterial(tbj38Cond));
        /** 2015/10/14 JASRAC対応 HLC K.Soga ADD End */

        //契約情報の取得
        List<MaterialRegisterCntrctVO> cntrctList = dao.findMaterialListForCntrctByCondition(cond);
        result.setCntrctList(cntrctList);

        //カテゴリリスト用データの取得
        Tbj16ContractInfoDAO ctrtDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
        List<Tbj16ContractInfoVO> categoryList = ctrtDao.getCategory();
        result.setCategoryList(categoryList);

        /** 2016/02/29 HDX対応 HLC K.Soga ADD Start */
        //車種担当者姓、名取得
        Mbj52SzTntUserDAO mbj52Dao = Mbj52SzTntUserDAOFactory.createMbj52SzTntUserDAO();
        Mbj52SzTntUserCondition mbj52Cond = new Mbj52SzTntUserCondition();
        result.setSzTntUserList(mbj52Dao.findSyatanUser(mbj52Cond));

        //セキュリティグループユーザー(HC/HM)取得
        FindSecGrpUserDAO findSecGrpUserDao = FindSecGrpUserDAOFactory.createFindSecGrpUserDAOFactory();
        FindSecGrpUserCondition findSecGrpUserCond = new FindSecGrpUserCondition();
        result.setHCHMSecGrpUserList(findSecGrpUserDao.findHCHMSecGrpUser(findSecGrpUserCond));
        /** 2016/02/29 HDX対応 HLC K.Soga ADD End */

        return result;
    }

    /**
     * 素材情報ログデータを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialRegisterResult findLogMaterialRegisterList(MaterialRegisterCondition cond) throws HAMException {

        MaterialRegisterResult result = new MaterialRegisterResult();
        MaterialRegisterDAO dao = MaterialRegisterDAOFactory.createFindMaterialListDao();

        /** 2015/11/24 JASRAC対応 HLC K.Soga ADD Start */
        //仮10桁CMコード取得
        cond.setTempCmCd(cond.getCmCd());
        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj36TempSozaiKanriDataCondition tbj36Cond = new Tbj36TempSozaiKanriDataCondition();
        tbj36Cond.setCmcd(cond.getCmCd());
        List<Tbj36TempSozaiKanriDataVO> tbj36List = tbj36Dao.selectVO(tbj36Cond);

        //取得した仮素材データが存在する場合
        if (tbj36List.size() > 0) {
            cond.setTempCmCd(tbj36List.get(0).getTEMPCMCD());
        }
        /** 2015/11/24 JASRAC対応 HLC K.Soga ADD End */

        //素材ログ取得
        List<LogMaterialRegisterVO> logList = dao.findLogMaterialRegisterByCondition(cond);
        result.setMaterialRegisterLogList(logList);

        return result;
    }

    /**
     * コンテンツ情報と素材情報を登録します
     * @param vo
     * @return
     */
    public MaterialRegisterResult executeContentMaterialInfo(RegisterMaterialVO vo) throws HAMException {

        //排他制御
        if (!this.isExclusionForMaterialContent(vo)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        Tbj17ContentDAO contDao = Tbj17ContentDAOFactory.createTbj17ContentDAO();
        Tbj18SozaiKanriDataDAO materialDao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();
        MaterialRegisterDAO dao = MaterialRegisterDAOFactory.createFindMaterialListDao();
        /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
        Tbj42SozaiKanriListCmnDAO tbj42Dao = Tbj42SozaiKanriListCmnDAOFactory.createTbj42SozaiKanriListCmnDAO();
        Tbj43SozaiKanriListCmnOADAO tbj43Dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        RegisterLogMaterialListCmnDAO regLogMaterialListCmnDao = RegisterLogMaterialListCmnDAOFactory.createLogMaterialListCmnDAO();
        RegisterLogMaterialListCmnOADAO regLogMaterialListCmnOADao = RegisterLogMaterialListCmnOADAOFactory.createLogMaterialListCmnOADAO();
        UpdateMaterialListCmnDAO updateMaterialListCmnDao = UpdateMaterialListCmnDAOFactory.createUpdateMaterialListCmnDAO();
        UpdateMaterialListCmnOADAO updateMaterialListCmnOADao = UpdateMaterialListCmnOADAOFactory.createUpdateMaterialListCmnOADAO();
        /** 2016/03/10 HDX対応 HLC K.Soga ADD End */

        /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
        /* 車種変換マスタ更新用VOリスト */
        List<Tbj20SozaiKanriListVO> tbj20CarConvertVoList = new ArrayList<Tbj20SozaiKanriListVO>();
        /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */

        //登録・更新のコンテンツデータをまとめたリスト.
        List<Tbj17ContentVO> allContentVoList = new ArrayList<Tbj17ContentVO>();
        //仮契約番号と採番した契約番号を紐づける
        Map<String, String> ctrtNoMap = new HashMap<String, String>();
        //仮CMコードと採番したCMコードを紐づける
        Map<String, String> cmCdMap = new HashMap<String, String>();

        //素材登録Step1：削除処理
        if (vo.getDelVOList() != null) {
            //削除件数分ループ処理
            for (RegisterMaterialContentVO rmDelVo : vo.getDelVOList()) {

                /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
                //素材一覧
                MaterialRegisterCondition cond = new MaterialRegisterCondition();
                cond.setCmCd(rmDelVo.getCMCD());
                List<Tbj20SozaiKanriListVO> tbj20VoList = dao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_ACTUAL);
                /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */

                //素材登録ログ
                Tbj25LogSozaiKanriDataVO logVo = getMaterialRegisterLogVo(rmDelVo, HAMConstants.HISTORYKBN_DELETE);
                dao.insertMaterialRegisterLog(logVo);
                //素材登録
                materialDao.deleteVO(rmDelVo);

                //コンテンツの一括削除処理
                dao.deleteTaregetContentAll(rmDelVo);

                /** 2016/03/11 HDX対応 HLC K.Soga DEL Start */
                ////素材一覧の更新
                //rmDelVo.setUPDDATE(new Date());
                //dao.updateDelMaterialList(rmDelVo);
                ////素材一覧ログ.
                //Tbj26LogSozaiKanriListVO logLstVo = new Tbj26LogSozaiKanriListVO();
                //logLstVo.setCMCD(rmDelVo.getCMCD());
                //logLstVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DELETE);
                ///** 2014/10/30 マスタ追加対応 HLC K.Soga ADD Start */
                ////作成区分
                //logLstVo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                ///** 2014/10/30 マスタ追加対応 HLC K.Soga ADD End */
                //dao.insertMaterialListLog(logLstVo);
                /** 2016/03/11 HDX対応 HLC K.Soga DEL End */

                /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
                if (tbj20VoList.size() != 0) {

                    //素材一覧更新
                    dao.updateDelMaterialList(rmDelVo);

                    /** 2016/03/11 HDX対応 HLC K.Soga ADD Start */
                    for(int i = 0; i< tbj20VoList.size(); i++){
                        //素材一覧(共有)更新
                        Tbj42SozaiKanriListCmnVO tbj42Vo = new Tbj42SozaiKanriListCmnVO();
                        tbj42Vo.setDELFLG(HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE);
                        tbj42Vo.setCMCD(rmDelVo.getCMCD());
                        if(tbj20VoList.get(i).getTEMPCMCD().length() > 0){
                            tbj42Vo.setTEMPCMCD(tbj20VoList.get(i).getTEMPCMCD());
                        }else{
                            tbj42Vo.setTEMPCMCD(null);
                        }
                        tbj42Vo.setUPDNM(rmDelVo.getUPDNM());
                        tbj42Vo.setUPDAPL(rmDelVo.getUPDAPL());
                        tbj42Vo.setUPDID(rmDelVo.getUPDID());
                        tbj42Dao.updateDelFlg(tbj42Vo);

                        //素材一覧(共有OA期間)更新
                        Tbj43SozaiKanriListCmnOAVO tbj43Vo = new Tbj43SozaiKanriListCmnOAVO();
                        tbj43Vo.setDELFLG(HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE);
                        tbj43Vo.setCMCD(rmDelVo.getCMCD());
                        if(tbj20VoList.get(i).getTEMPCMCD().length() > 0){
                            tbj43Vo.setTEMPCMCD(tbj20VoList.get(i).getTEMPCMCD());
                        }else{
                            tbj43Vo.setTEMPCMCD(null);
                        }
                        tbj43Vo.setUPDNM(rmDelVo.getUPDNM());
                        tbj43Vo.setUPDAPL(rmDelVo.getUPDAPL());
                        tbj43Vo.setUPDID(rmDelVo.getUPDID());
                        tbj43Dao.updateDelFlg(tbj43Vo);
                        /** 2016/03/11 HDX対応 HLC K.Soga ADD End */
                    }

                    //車種変換マスタ更新用VOリストに追加
                    for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD Start */
                        tbj20Vo.setUPDNM(rmDelVo.getUPDNM());
                        tbj20Vo.setUPDID(rmDelVo.getUPDID());
                        tbj20Vo.setUPDAPL(rmDelVo.getUPDAPL());
                        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD End */
                        tbj20CarConvertVoList.add(tbj20Vo);
                    }
                }
                /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */
            }
        }

        //素材登録Step2：新規登録
        if (vo.getRegVOList() != null) {
            for (RegisterMaterialContentVO rmRegVo : vo.getRegVOList()) {

                //採番テーブルの取得
                Tbj15CmCodeDAO tbj15Dao = Tbj15CmCodeDAOFactory.createTbj15CmCodeDAO();
                Tbj15CmCodeCondition tbj15Cond = new Tbj15CmCodeCondition();
                tbj15Cond.setNokbn(rmRegVo.getNOKBN());
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);

                //発行済み番号のカウントアップ
                int existNo = tbj15Vo.getEXISTNO().intValue() + 1;
                if (existNo > 9999) {
                    throw new HAMException("自動採番桁あふれ", "BJ-E0008");
                }

                //発行済み番号のカウントアップを行った段階で更新
                tbj15Vo.setEXISTNO(new BigDecimal(existNo));
                tbj15Vo.setUPDDATE(new Date());
                tbj15Vo.setUPDAPL(rmRegVo.getUPDAPL());
                tbj15Vo.setUPDID(rmRegVo.getUPDID());
                tbj15Vo.setUPDNM(rmRegVo.getUPDNM());
                tbj15Dao.updateVO(tbj15Vo);

                String newCmCd = "0244=" + tbj15Vo.getCNTKBN() + existNo;

                //登録処理
                //既にセットされている仮番号をキーとして採番した番号を保持
                cmCdMap.put(rmRegVo.getCMCD(), newCmCd);
                rmRegVo.setCMCD(newCmCd);
                materialDao.insertVO(rmRegVo);

                Tbj25LogSozaiKanriDataVO tbj25Vo = getMaterialRegisterLogVo(rmRegVo, HAMConstants.HISTORYKBN_REGSTER);
                dao.insertMaterialRegisterLog(tbj25Vo);

                //契約情報がある場合
                if (rmRegVo.getTbj17ContentVOList() != null) {
                    allContentVoList.addAll(rmRegVo.getTbj17ContentVOList());
                }
            }
        }

        //素材登録Step3：更新処理
        if (vo.getUpdVOList() != null) {
            for (RegisterMaterialContentVO rmUpdVo : vo.getUpdVOList()) {

                //更新処理
                materialDao.updateVO(rmUpdVo);

                Tbj25LogSozaiKanriDataVO tbj25Vo = getMaterialRegisterLogVo(rmUpdVo, HAMConstants.HISTORYKBN_UPDATE);
                dao.insertMaterialRegisterLog(tbj25Vo);

                //コンテンツの一括削除処理
                dao.deleteTaregetContentAll(rmUpdVo);

                //各コンテンツの追加
                if (rmUpdVo.getTbj17ContentVOList() != null) {
                    allContentVoList.addAll(rmUpdVo.getTbj17ContentVOList());
                }

                MaterialRegisterCondition cond = new MaterialRegisterCondition();
                cond.setCmCd(rmUpdVo.getCMCD());
                List<Tbj20SozaiKanriListVO> tbj20VoList = dao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_ACTUAL);

                /** 2016/03/31 HDX対応 HLC K.Soga ADD Start */
                //素材一覧(共通OA期間)更新用フラグ：RecNoがNULLのレコードのみが更新対象
                Boolean flg = false;
                /** 2016/03/31 HDX対応 HLC K.Soga ADD End */

                //車種の変更チェック
                if (tbj20VoList.size() <= 0) {
                    continue;
                }
                for(int i = 0; i < tbj20VoList.size(); i++){
                    //車種が変更されていない場合
                    if (rmUpdVo.getDCARCD().equals(tbj20VoList.get(i).getDCARCD())) {
                        //素材一覧
                        Tbj20SozaiKanriListVO tbj20Vo = tbj20VoList.get(i);
                        //年月→変更しないため、null指定
                        //tbj20Vo.setSOZAIYM(null);
                        //作成番号→変更しないため、null指定
                        tbj20Vo.setRECNO(null);
                        //車種コード→変更しないため、null指定
                        tbj20Vo.setDCARCD(null);
                        //タイトル
                        tbj20Vo.setTITLE(rmUpdVo.getTITLE());
                        //秒数
                        tbj20Vo.setSECOND(rmUpdVo.getSECOND());
                        //使用期限期間
                        tbj20Vo.setLIMIT(rmUpdVo.getMLIMIT());
                        /** 2016/03/10 HDX対応 HLC K.Soga DEL Start */
                        ////車種担当
                        //updVo.setSYATAN(rmUpdVo.getSYATAN());
                        /** 2016/03/10 HDX対応 HLC K.Soga DEL End */
                        //データ更新者
                        tbj20Vo.setUPDNM(rmUpdVo.getUPDNM());
                        /** 2015/2/17 素材登録不具合対応 HLC K.Soga DEL Start */
                        //データ更新日
                        //updVo.setUPDDATE((new Date()));
                        /** 2015/2/17 素材登録不具合対応 HLC K.Soga DEL End */
                        //更新プログラム
                        tbj20Vo.setUPDAPL(rmUpdVo.getUPDAPL());
                        //更新担当者ID
                        tbj20Vo.setUPDID(rmUpdVo.getUPDID());
                        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD Start */
                        //dao.updateMaterialList(updVo);
                        dao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_ACTUAL);
                        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD End */

                        //素材一覧ログ
                        Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                        /** 2014/10/30 マスタ追加対応 HLC K.Soga MOD Start */
                        //listLogVo.setDCARCD(updVo.getDCARCD());
                        //listLogVo.setRECKBN(updVo.getRECKBN());
                        //listLogVo.setRECNO(updVo.getRECNO());
                        tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                        tbj26Vo.setCMCD(rmUpdVo.getCMCD());
                        tbj26Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                        /** 2014/10/30 マスタ追加対応 HLC K.Soga MOD End */
                        tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                        dao.insertMaterialListLog(tbj26Vo);

                        /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
                        //素材一覧ログのHISTORYNO取得
                        tbj20Vo.setCMCD(tbj20Vo.getCMCD());
                        tbj20Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                        List<Tbj26LogSozaiKanriListVO> tbj26VoList = getMaxHistoryNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);
                        //素材一覧(共通)
                        Tbj42SozaiKanriListCmnCondition tbj42Cond = new Tbj42SozaiKanriListCmnCondition();
                        tbj42Cond.setCmcd(tbj20Vo.getCMCD());
                        tbj42Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                        List<Tbj42SozaiKanriListCmnVO> tbj42VoList = tbj42Dao.selectVO(tbj42Cond);
                        if(tbj42VoList.size() > 0){
                            Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                            tbj44Vo.setSOZAIYM(tbj42VoList.get(0).getSOZAIYM());
                            tbj44Vo.setCMCD(tbj20Vo.getCMCD());
                            tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                            tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);
                        }
                        //素材一覧(共通OA期間)
                        Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                        tbj43Cond.setCmcd(tbj20Vo.getCMCD());
                        tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                        List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NOT_NULL);
                        if(tbj43VoList.size() > 0){
                            //素材一覧(共有OA期間)ログ
                            Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                            tbj45Vo.setDCARCD(tbj43VoList.get(0).getDCARCD());
                            tbj45Vo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                            tbj45Vo.setRECKBN(tbj43VoList.get(0).getRECKBN());
                            tbj45Vo.setRECNO(tbj43VoList.get(0).getRECNO());
                            tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD Start */
                            tbj45Vo.setCMCD(tbj43VoList.get(0).getCMCD());
                            if(tbj43VoList.get(0).getTEMPCMCD().length() > 0){
                                tbj45Vo.setTEMPCMCD(tbj43VoList.get(0).getTEMPCMCD());
                            }
                            /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                            regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                        }
                        /** 2016/03/10 HDX対応 HLC K.Soga ADD End */

                    //車種が変更されている場合
                    } else {
                        //素材一覧
                        Tbj20SozaiKanriListVO tbj20Vo = tbj20VoList.get(i);
                        /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
                        //素材年月の最大値取得
                        List<Tbj43SozaiKanriListCmnOAVO> prevSozaiym = getMaxSozaiYm(tbj20Vo.getDCARCD(), tbj20Vo.getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                        Date MaxSozaiYm = tbj20Vo.getSOZAIYM();
                        if(prevSozaiym.get(0).getSOZAIYM() != null){
                            MaxSozaiYm = prevSozaiym.get(0).getSOZAIYM();
                        }
                        /** 2016/03/22 HDX対応 HLC K.Soga ADD End */
                        //車種コード
                        tbj20Vo.setDCARCD(rmUpdVo.getDCARCD());
                        //タイトル
                        tbj20Vo.setTITLE(rmUpdVo.getTITLE());
                        //秒数
                        tbj20Vo.setSECOND(rmUpdVo.getSECOND());
                        //使用期限期間
                        tbj20Vo.setLIMIT(rmUpdVo.getMLIMIT());
                        //車種担当
                        tbj20Vo.setSYATAN(rmUpdVo.getSYATAN());
                        /** 2015/2/17 素材登録不具合対応 HLC K.Soga DEL Start */
                        //データ更新日
                        //updVo.setUPDDATE((new Date()));
                        /** 2015/2/17 素材登録不具合対応 HLC K.Soga DEL End */
                        //データ更新者
                        tbj20Vo.setUPDNM(rmUpdVo.getUPDNM());
                        //更新プログラム
                        tbj20Vo.setUPDAPL(rmUpdVo.getUPDAPL());
                        //更新担当者ID
                        tbj20Vo.setUPDID(rmUpdVo.getUPDID());
                        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD Start */
                        //dao.updateMaterialList(updVo);
                        dao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_ACTUAL);
                        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD End */

                        //素材一覧ログ
                        Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                        /** 2014/10/30 マスタ追加対応 HLC K.Soga MOD Start */
                        //listLogVo.setDCARCD(updVo.getDCARCD());
                        //listLogVo.setRECKBN(updVo.getRECKBN());
                        //listLogVo.setRECNO(updVo.getRECNO());
                        tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                        tbj26Vo.setCMCD(rmUpdVo.getCMCD());
                        tbj26Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                        /** 2014/10/30 マスタ追加対応 HLC K.Soga MOD End */
                        tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                        dao.insertMaterialListLog(tbj26Vo);

                        /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
                        //素材一覧のNEWNO(RECNO)取得
                        if(tbj20Vo.getTEMPCMCD().length() > 0){
                            tbj20Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                        }else{
                            tbj20Vo.setTEMPCMCD(null);
                        }
                        List<Tbj20SozaiKanriListVO> newNoVoList = getNewNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);
                        if(newNoVoList.size() > 0){
                            //素材一覧(共通)
                            Tbj42SozaiKanriListCmnVO tbj42Vo = new Tbj42SozaiKanriListCmnVO();
                            tbj42Vo.setDCARCD(tbj20Vo.getDCARCD());
                            tbj42Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                            tbj42Vo.setUPDAPL(tbj20Vo.getUPDAPL());
                            tbj42Vo.setUPDID(tbj20Vo.getUPDID());
                            tbj42Vo.setCMCD(tbj20Vo.getCMCD());
                            tbj42Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                            tbj42Vo.setRECNO(newNoVoList.get(0).getRECNO());
                            updateMaterialListCmnDao.updateSQLMaterialListCmn(tbj42Vo, HAMConstants.MATERIAL_KBN_ACTUAL);

                            //素材一覧(共通OA期間)
                            Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                            tbj43Cond.setCmcd(tbj20Vo.getCMCD());
                            tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                            List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NOT_NULL);
                            if(tbj43VoList.size() > 0){
                                //素材年月の最大値取得
                                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiym = getMaxSozaiYm(tbj20Vo.getDCARCD(), tbj43VoList.get(0).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                                Tbj43SozaiKanriListCmnOAVO tbj43Vo = new Tbj43SozaiKanriListCmnOAVO();
                                tbj43Vo.setDCARCD(tbj20Vo.getDCARCD());
                                tbj43Vo.setUPDAPL(tbj20Vo.getUPDAPL());
                                tbj43Vo.setUPDID(tbj20Vo.getUPDID());
                                tbj43Vo.setCMCD(tbj20Vo.getCMCD());
                                tbj43Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                                tbj43Vo.setRECNO(newNoVoList.get(0).getRECNO());
                                if(maxSozaiym.get(0).getSOZAIYM() != null){
                                    tbj43Vo.setSOZAIYM(maxSozaiym.get(0).getSOZAIYM());
                                    MaxSozaiYm = tbj43Vo.getSOZAIYM();
                                }else{
                                    tbj43Vo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                                }
                                updateMaterialListCmnOADao.updateSQLMaterialListCmnOA(tbj43Vo, HAMConstants.MATERIAL_KBN_ACTUAL);
                            }
                            //素材一覧ログのHISTORYNO取得
                            List<Tbj26LogSozaiKanriListVO> tbj26VoList = getMaxHistoryNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);
                            if(tbj26VoList.size() > 0 && tbj43VoList.size() > 0){
                                //素材一覧ログ(共通)
                                Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                                tbj44Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                                tbj44Vo.setCMCD(rmUpdVo.getCMCD());
                                tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                                tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                                tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                tbj44Vo.setRECNO(newNoVoList.get(0).getRECNO());
                                regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);

                                //素材一覧(共有OA期間)ログ
                                Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                                tbj45Vo.setSOZAIYM(MaxSozaiYm);
                                tbj45Vo.setCMCD(rmUpdVo.getCMCD());
                                tbj45Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                                tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                                tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                            }

                            //素材一覧(共通OA期間)更新：RecNoがNULLのレコードのみが更新対象
                            if(!flg){
                                List<Tbj43SozaiKanriListCmnOAVO> RecNoIsNullVoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NULL);
                                for(int j =0; j < RecNoIsNullVoList.size(); j++){
                                    //素材年月の最大値取得
                                    List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm = getMaxSozaiYm(tbj20Vo.getDCARCD(), RecNoIsNullVoList.get(j).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                                    if(maxSozaiYm.get(0).getSOZAIYM() != null){
                                        tbj43Cond.setSozaiym(maxSozaiYm.get(0).getSOZAIYM());
                                    }else{
                                        tbj43Cond.setSozaiym(RecNoIsNullVoList.get(j).getSOZAIYM());
                                    }
                                    tbj43Cond.setDcarcd(tbj20Vo.getDCARCD());
                                    tbj43Cond.setUpdapl(tbj20Vo.getUPDAPL());
                                    tbj43Cond.setUpdid(tbj20Vo.getUPDID());
                                    tbj43Cond.setUpdnm(tbj20Vo.getUPDNM());
                                    updateMaterialListCmnOADao.updateDcarCd(tbj43Cond);
                                }
                                flg = true;
                            }
                        }
                        /** 2016/03/10 HDX対応 HLC K.Soga ADD End */

                        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD Start */
                        tbj20CarConvertVoList.add(tbj20Vo);
                        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD End */
                    }
                }
            }
        }

        //素材登録Step4：契約更新処理
        if (vo.getUpdCntrctList() != null) {
            ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();

            for (Tbj16ContractInfoUpdateVO cntrctVo : vo.getUpdCntrctList()) {
                Tbj16ContractInfoUpdateVO updateVo = cntrctVo;
                if (!cntrctVo.getCTRTKBN().equals(cntrctVo.getCTRTKBNOLD())) {
                    //契約コードのMAX値の検索
                    String getCtrtNo = contractRegisterDao.searchCtrtNoByCondition(cntrctVo);

                    //既にセットされている仮番号をキーとして採番した番号を保持
                    ctrtNoMap.put(updateVo.getCTRTKBN() + "|" + updateVo.getCTRTNO(), getCtrtNo);
                    updateVo.setCTRTNONEW(getCtrtNo);
                } else {
                    updateVo.setCTRTNONEW(updateVo.getCTRTNO());
                }

                if (updateVo.getHISTORYKEY() == null) {
                    //履歴キーの採番・セット.
                    Tbj16ContractInfoDAO contractDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
                    Tbj16ContractInfoCondition contractCond = new Tbj16ContractInfoCondition();
                    List<Tbj16ContractInfoVO> contractVo = contractDao.findMax(contractCond);
                    BigDecimal historyKey = contractVo.get(0).getHISTORYKEY().add(BigDecimal.ONE);
                    updateVo.setHISTORYKEY(historyKey);
                }
                contractRegisterDao.updateContractInfoCondition(updateVo);

                //履歴の登録
                Tbj24LogContractInfoVO logContractInfoVo = new Tbj24LogContractInfoVO();
                logContractInfoVo.setCTRTKBN(cntrctVo.getCTRTKBN());
                logContractInfoVo.setCTRTNO(cntrctVo.getCTRTNO());
                logContractInfoVo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);
            }
        }

        //契約情報テーブルのDelete（論理削除）
        if (vo.getDelCntrctList() != null) {

            Tbj16ContractInfoDAO ctrtDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
            ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();
            Tbj19JasracDAO jasracDao = Tbj19JasracDAOFactory.createTbj19JasracDAO();

            for (int i = 0; i < vo.getDelCntrctList().size(); i++) {
                //契約情報テーブル,
                Tbj16ContractInfoVO deleteVo = new Tbj16ContractInfoVO();
                deleteVo.setCTRTKBN(vo.getDelCntrctList().get(i).getCTRTKBN());
                deleteVo.setCTRTNO(vo.getDelCntrctList().get(i).getCTRTNO());
                deleteVo.setDELFLG(HAMConstants.CONTRACT_REGISTER_DELFLG_DELETE);
                ctrtDao.updateVO(deleteVo);

                //履歴の登録
                Tbj24LogContractInfoVO logContractInfoVo = new Tbj24LogContractInfoVO();
                logContractInfoVo.setCTRTKBN(vo.getDelCntrctList().get(i).getCTRTKBN());
                logContractInfoVo.setCTRTNO(vo.getDelCntrctList().get(i).getCTRTNO());
                logContractInfoVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DELETE);
                contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);

                //JASRACテーブルの論理削除
                Tbj19JasracVO jasracVo = new Tbj19JasracVO();
                jasracVo.setDELFLG("D");
                Tbj19JasracCondition jasracCond = new Tbj19JasracCondition();
                jasracCond.setCtrtkbn(vo.getDelCntrctList().get(i).getCTRTKBN());
                jasracCond.setCtrtno(vo.getDelCntrctList().get(i).getCTRTNO());
                jasracDao.updateVOByCond(jasracVo, jasracCond);

                //コンテンツテーブル削除
                Tbj17ContentVO contCond = new Tbj17ContentVO();
                contCond.setCTRTKBN(vo.getDelCntrctList().get(i).getCTRTKBN());
                contCond.setCTRTNO(vo.getDelCntrctList().get(i).getCTRTNO());
                contDao.deleteByVo(contCond);
            }
        }

        //契約情報テーブルのInsert
        if (vo.getRegCntrctList() != null) {

            ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();

            for (int i = 0; i < vo.getRegCntrctList().size(); i++) {
                //契約コードのMAX値の検索
                Tbj16ContractInfoUpdateVO ctrtUpdVo = new Tbj16ContractInfoUpdateVO();
                ctrtUpdVo.setCTRTKBN(vo.getRegCntrctList().get(i).getCTRTKBN());
                String getCtrtNo = contractRegisterDao.searchCtrtNoByCondition(ctrtUpdVo);
                Tbj16ContractInfoVO insertVo = vo.getRegCntrctList().get(i);
                //既にセットされている仮番号をキーとして採番した番号を保持
                ctrtNoMap.put(insertVo.getCTRTKBN() + "|" + insertVo.getCTRTNO(), getCtrtNo);
                insertVo.setCTRTNO(getCtrtNo);
                //履歴キーの採番・セット.
                Tbj16ContractInfoDAO contractDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
                Tbj16ContractInfoCondition contractCond = new Tbj16ContractInfoCondition();
                List<Tbj16ContractInfoVO> contractVo = contractDao.findMax(contractCond);
                BigDecimal historyKey = contractVo.get(0).getHISTORYKEY().add(BigDecimal.ONE);
                insertVo.setHISTORYKEY(historyKey);

                contractDao.insertVO(insertVo);

                //履歴の登録
                Tbj24LogContractInfoVO logContractInfoVo = new Tbj24LogContractInfoVO();
                logContractInfoVo.setCTRTKBN(vo.getRegCntrctList().get(i).getCTRTKBN());
                logContractInfoVo.setCTRTNO(vo.getRegCntrctList().get(i).getCTRTNO());
                logContractInfoVo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGSTER);
                contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);
            }
        }

        //コンテンツテーブルの登録
        if (allContentVoList != null) {
            for (Tbj17ContentVO contVo : allContentVoList) {
                if (ctrtNoMap.containsKey(contVo.getCTRTKBN() + "|" + contVo.getCTRTNO())) {
                    //仮番号が入っている場合は採番した値に置き換える
                    contVo.setCTRTNO(ctrtNoMap.get(contVo.getCTRTKBN() + "|" + contVo.getCTRTNO()));
                }
                if (cmCdMap.containsKey(contVo.getCMCD())) {
                    //仮番号が入っている場合は採番した値に置き換える
                    contVo.setCMCD(cmCdMap.get(contVo.getCMCD()));
                }
                contDao.insertVO(contVo);
            }
        }

        /** 2015/11/11 JASRAC対応 HLC K.Soga ADD Start */
        //仮素材削除
        if (vo.getTbj36DelVo() != null && !vo.getTbj36DelVo().equals("")) {
            deleteTempSozai(vo, tbj20CarConvertVoList);
        }

        //仮素材更新
        if (vo.getTbj36UpdVo() != null && !vo.getTbj36UpdVo().equals("")) {
            updTempSozai(vo, ctrtNoMap, tbj20CarConvertVoList);
        }

        //仮素材追加
        if (vo.getTbj36InsVo() != null && !vo.getTbj36InsVo().equals("")) {
            regTempSozai(vo, ctrtNoMap);
        }

        //車種変換マスタ更新VO
        Mbj38CarConvertVO mbj38Vo = new Mbj38CarConvertVO();

        if (tbj20CarConvertVoList.size() != 0) {

            //車種変換マスタ更新VOリスト全件ループ処理
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20CarConvertVoList) {

                mbj38Vo = ContractMaterialUtil.getCarConvertUpdateVo(tbj20Vo);

                //車種変換マスタ削除処理
                Mbj38CarConvertDAO mbj38Dao = Mbj38CarConvertDAOFactory.createMbj38CarConvertDAO();
                mbj38Dao.deleteByMonth(mbj38Vo);

                //車種変換マスタ追加処理
                dao.insertCarConvert(mbj38Vo);
            }
        }
        /** 2015/11/11 JASRAC対応 HLC K.Soga ADD End */

        return new MaterialRegisterResult();
    }

    /** 2015/11/10 JASRAC対応 HLC S.Fujimoto ADD Start */
    /**
     * 本素材登録
     * @param vo 仮素材の本素材登録時VO
     * @return 本素材登録結果セット
     * @throws HAMException
     */
    public RegisterRealMaterialFromTempMaterialResult registerRealMaterialFromTempMaterial(RegisterRealMaterialFromTempMaterialVO vo) throws HAMException {

        RegisterRealMaterialFromTempMaterialResult result = new RegisterRealMaterialFromTempMaterialResult();

        //本素材最大値取得
        Tbj15CmCodeDAO tbj15Dao = Tbj15CmCodeDAOFactory.createTbj15CmCodeDAO();
        Tbj15CmCodeCondition tbj15Cond = new Tbj15CmCodeCondition();
        Tbj17ContentDAO tbj17Dao = Tbj17ContentDAOFactory.createTbj17ContentDAO();
        Tbj18SozaiKanriDataDAO tbj18Dao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();
        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        MaterialRegisterDAO materialRegisterDao = MaterialRegisterDAOFactory.createFindMaterialListDao();
        /** 2016/03/14 HDX対応 HLC K.Soga ADD Start */
        Tbj42SozaiKanriListCmnDAO tbj42Dao = Tbj42SozaiKanriListCmnDAOFactory.createTbj42SozaiKanriListCmnDAO();
        Tbj43SozaiKanriListCmnOADAO tbj43Dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        RegisterLogMaterialListCmnDAO regLogMaterialListCmnDao = RegisterLogMaterialListCmnDAOFactory.createLogMaterialListCmnDAO();
        RegisterLogMaterialListCmnOADAO regLogMaterialListCmnOADao = RegisterLogMaterialListCmnOADAOFactory.createLogMaterialListCmnOADAO();
        UpdateMaterialListCmnOADAO updateMaterialListCmnOADao = UpdateMaterialListCmnOADAOFactory.createUpdateMaterialListCmnOADAO();
        /** 2016/03/14 HDX対応 HLC K.Soga ADD End */

        /* 車種変換マスタ更新用VOリスト */
        List<Tbj20SozaiKanriListVO> tbj20CarConvertVoList = new ArrayList<Tbj20SozaiKanriListVO>();

        for (int i = 0; i < vo.getTbj36UpdVo().size(); i++) {

            String newNo = null;

            //タイム
            if (vo.getTbj36UpdVo().get(i).getNOKBN().equals(HAMConstants.NOKBN_TIME)) {
                tbj15Cond.setNokbn(HAMConstants.NOKBN_TIME);
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);
                BigDecimal maxTimeNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));
                String cntKbnTime = tbj15Vo.getCNTKBN();

                newNo = NEWNO.replace("XX", cntKbnTime).replace("YYYY", String.format("%04d", maxTimeNo.intValue()));

                //自動採番更新
                tbj15Vo.setNOKBN(HAMConstants.NOKBN_TIME);
                tbj15Vo.setEXISTNO(maxTimeNo);
                tbj15Vo.setUPDNM(vo.getTbj36UpdVo().get(i).getUPDNM());
                tbj15Vo.setUPDAPL(vo.getTbj36UpdVo().get(i).getUPDAPL());
                tbj15Vo.setUPDID(vo.getTbj36UpdVo().get(i).getUPDID());
                tbj15Dao.updateVO(tbj15Vo);
            }
            //スポット
            else if (vo.getTbj36UpdVo().get(i).getNOKBN().equals(HAMConstants.NOKBN_SPOT)) {
                tbj15Cond.setNokbn(HAMConstants.NOKBN_SPOT);
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);
                BigDecimal maxSpotNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));
                String cntKbnSpot= tbj15Vo.getCNTKBN();

                newNo = NEWNO.replace("XX", cntKbnSpot).replace("YYYY", String.format("%04d", maxSpotNo.intValue()));

                //自動採番更新
                tbj15Vo.setNOKBN(HAMConstants.NOKBN_SPOT);
                tbj15Vo.setEXISTNO(maxSpotNo);
                tbj15Vo.setUPDNM(vo.getTbj36UpdVo().get(i).getUPDNM());
                tbj15Vo.setUPDAPL(vo.getTbj36UpdVo().get(i).getUPDAPL());
                tbj15Vo.setUPDID(vo.getTbj36UpdVo().get(i).getUPDID());
                tbj15Dao.updateVO(tbj15Vo);
            }
            //ラジオ
            else if (vo.getTbj36UpdVo().get(i).getNOKBN().equals(HAMConstants.NOKBN_RADIO)) {
                tbj15Cond.setNokbn(HAMConstants.NOKBN_RADIO);
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);
                BigDecimal maxRadioNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));
                String cntKbnRadio = tbj15Vo.getCNTKBN();

                newNo = NEWNO.replace("XX", cntKbnRadio).replace("YYYY", String.format("%04d", maxRadioNo.intValue()));

                //自動採番更新
                tbj15Vo.setNOKBN(HAMConstants.NOKBN_RADIO);
                tbj15Vo.setEXISTNO(maxRadioNo);
                tbj15Vo.setUPDNM(vo.getTbj36UpdVo().get(i).getUPDNM());
                tbj15Vo.setUPDAPL(vo.getTbj36UpdVo().get(i).getUPDAPL());
                tbj15Vo.setUPDID(vo.getTbj36UpdVo().get(i).getUPDID());
                tbj15Dao.updateVO(tbj15Vo);
            }

            //仮素材
            vo.getTbj36UpdVo().get(i).setCMCD(newNo);
            tbj36Dao.updateVO(vo.getTbj36UpdVo().get(i));

            //仮素材登録変更ログ
            Tbj41LogTempSozaiKanriDataVO tbj41Vo = new Tbj41LogTempSozaiKanriDataVO();
            tbj41Vo.setNOKBN(vo.getTbj36UpdVo().get(i).getNOKBN());
            tbj41Vo.setTEMPCMCD(vo.getTbj36UpdVo().get(i).getTEMPCMCD());
            tbj41Vo.setCMCD(vo.getTbj36UpdVo().get(i).getCMCD());
            tbj41Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP_TO_ACTUAL);
            materialRegisterDao.insertTempMaterialRegisterLog(tbj41Vo);

            //本素材
            Tbj18SozaiKanriDataVO tbj18Vo = new Tbj18SozaiKanriDataVO();
            tbj18Vo.setNOKBN(vo.getTbj36UpdVo().get(i).getNOKBN());
            tbj18Vo.setCMCD(newNo);
            tbj18Vo.setSTATUS(vo.getTbj36UpdVo().get(i).getSTATUS());
            tbj18Vo.setDCARCD(vo.getTbj36UpdVo().get(i).getDCARCD());
            tbj18Vo.setCATEGORY(vo.getTbj36UpdVo().get(i).getCATEGORY());
            tbj18Vo.setTITLE(vo.getTbj36UpdVo().get(i).getTITLE());
            /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
            tbj18Vo.setALIASTITLE(vo.getTbj36UpdVo().get(i).getALIASTITLE());
            tbj18Vo.setENDTITLE(vo.getTbj36UpdVo().get(i).getENDTITLE());
            tbj18Vo.setDATEFROM_ATTR(vo.getTbj36UpdVo().get(i).getDATEFROM_ATTR());
            tbj18Vo.setDATETO_ATTR(vo.getTbj36UpdVo().get(i).getDATETO_ATTR());
            /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
            tbj18Vo.setSECOND(vo.getTbj36UpdVo().get(i).getSECOND());
            /** 2016/02/17 HDX対応 HLC K.Soga DEL Start */
            //tbj18Vo.setSYATAN(vo.getTbj36UpdVo().get(i).getSYATAN());
            /** 2016/02/17 HDX対応 HLC K.Soga DEL End */
            tbj18Vo.setNOHIN(vo.getTbj36UpdVo().get(i).getNOHIN());
            tbj18Vo.setPRODUCT(vo.getTbj36UpdVo().get(i).getPRODUCT());
            tbj18Vo.setDATEFROM(vo.getTbj36UpdVo().get(i).getDATEFROM());
            tbj18Vo.setDATETO(vo.getTbj36UpdVo().get(i).getDATETO());
            tbj18Vo.setMLIMIT(vo.getTbj36UpdVo().get(i).getMLIMIT());
            tbj18Vo.setKLIMIT(vo.getTbj36UpdVo().get(i).getKLIMIT());
            tbj18Vo.setDATERECOG(vo.getTbj36UpdVo().get(i).getDATERECOG());
            tbj18Vo.setDATEPRT(vo.getTbj36UpdVo().get(i).getDATEPRT());
            tbj18Vo.setBIKO(vo.getTbj36UpdVo().get(i).getBIKO());
            tbj18Vo.setCRTNM(vo.getTbj36UpdVo().get(i).getCRTNM());
            tbj18Vo.setCRTAPL(vo.getTbj36UpdVo().get(i).getCRTAPL());
            tbj18Vo.setCRTID(vo.getTbj36UpdVo().get(i).getCRTID());
            tbj18Vo.setUPDNM(vo.getTbj36UpdVo().get(i).getUPDNM());
            tbj18Vo.setUPDAPL(vo.getTbj36UpdVo().get(i).getUPDAPL());
            tbj18Vo.setUPDID(vo.getTbj36UpdVo().get(i).getUPDID());
            tbj18Dao.insertVO(tbj18Vo);

            //素材登録変更ログ
            Tbj25LogSozaiKanriDataVO tbj25Vo = new Tbj25LogSozaiKanriDataVO();
            tbj25Vo.setNOKBN(tbj18Vo.getNOKBN());
            tbj25Vo.setCMCD(newNo);
            //本素材登録
            tbj25Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP_TO_ACTUAL);
            materialRegisterDao.insertMaterialRegisterLog(tbj25Vo);

            //契約仮素材紐付
            if (vo.getTbj40Vo() != null && !vo.getTbj40Vo().equals("")) {
                for (Tbj40TempSozaiContentVO tbj40Vo : vo.getTbj40Vo()) {
                    if (tbj40Vo.getTEMPCMCD().equals(vo.getTbj36UpdVo().get(i).getTEMPCMCD())) {
                        //コンテンツ
                        Tbj17ContentVO tbj17Vo = new Tbj17ContentVO();
                        tbj17Vo.setCMCD(newNo);
                        tbj17Vo.setCTRTKBN(tbj40Vo.getCTRTKBN());
                        tbj17Vo.setCTRTNO(tbj40Vo.getCTRTNO());
                        tbj17Vo.setCRTNM(tbj40Vo.getCRTNM());
                        tbj17Vo.setCRTAPL(tbj40Vo.getCRTAPL());
                        tbj17Vo.setCRTID(tbj40Vo.getCRTID());
                        tbj17Vo.setUPDNM(tbj40Vo.getUPDNM());
                        tbj17Vo.setUPDAPL(tbj40Vo.getUPDAPL());
                        tbj17Vo.setUPDID(tbj40Vo.getUPDID());
                        tbj17Dao.insertVO(tbj17Vo);
                    }
                }
            }

            // 素材一覧更新
            MaterialRegisterCondition cond = new MaterialRegisterCondition();
            cond.setTempCmCd(vo.getTbj36UpdVo().get(i).getTEMPCMCD());
            List<Tbj20SozaiKanriListVO> tbj20VoList = materialRegisterDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_TEMP);

            if (tbj20VoList == null) {
                continue;
            }
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {

                /** 2016/03/31 HDX対応 HLC K.Soga ADD Start */
                //素材一覧(共通OA期間)更新用フラグ：RecNoがNULLのレコードのみが更新対象
                Boolean flg = false;
                //素材年月の最大値取得
                List<Tbj43SozaiKanriListCmnOAVO> prevSozaiym = getMaxSozaiYm(tbj20Vo.getDCARCD(), tbj20Vo.getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                Date MaxSozaiYm = tbj20Vo.getSOZAIYM();
                if(prevSozaiym.get(0).getSOZAIYM() != null){
                    MaxSozaiYm = prevSozaiym.get(0).getSOZAIYM();
                }
                /** 2016/03/31 HDX対応 HLC K.Soga ADD End */

                //作成番号を採番させないために車種コードをnullに設定
                tbj20Vo.setDCARCD(null);
                tbj20Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                tbj20Vo.setCMCD(newNo);
                tbj20Vo.setTITLE(tbj18Vo.getTITLE());
                tbj20Vo.setSECOND(tbj18Vo.getSECOND());
                tbj20Vo.setLIMIT(tbj18Vo.getMLIMIT());
                /** 2016/02/17 HDX対応 HLC K.Soga DEL Start */
                //tbj20Vo.setSYATAN(tbj18Vo.getSYATAN());
                /** 2016/02/17 HDX対応 HLC K.Soga DEL End */
                tbj20Vo.setUPDNM(tbj18Vo.getUPDNM());
                tbj20Vo.setUPDAPL(tbj18Vo.getUPDAPL());
                tbj20Vo.setUPDID(tbj18Vo.getUPDID());

                // 素材一覧の更新
                materialRegisterDao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_TEMP);

                //車種変換マスタ更新用VOリストに追加
                tbj20CarConvertVoList.add(tbj20Vo);

                //素材一覧変更ログ追加
                Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                tbj26Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                tbj26Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP_TO_ACTUAL);
                materialRegisterDao.insertMaterialListLog(tbj26Vo);

                /** 2016/03/14 HDX対応 HLC K.Soga ADD Start */
                //素材一覧(共通)
                Tbj42SozaiKanriListCmnVO tbj42Vo = new Tbj42SozaiKanriListCmnVO();
                tbj42Vo.setDCARCD(tbj18Vo.getDCARCD());
                tbj42Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                tbj42Vo.setUPDAPL(tbj20Vo.getUPDAPL());
                tbj42Vo.setUPDID(tbj20Vo.getUPDID());
                tbj42Vo.setUPDNM(tbj20Vo.getUPDNM());
                tbj42Vo.setCMCD(tbj20Vo.getCMCD());
                tbj42Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                tbj42Vo.setRECNO(tbj20Vo.getRECNO());
                tbj42Dao.updateTempMaterial(tbj42Vo);

                //素材一覧(共通OA期間)
                Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                tbj43Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NOT_NULL);
                /** 2016/05/30 HDX不具合対応 HLC K.Soga MOD Start */
                //素材年月の最大値取得
                //List<Tbj43SozaiKanriListCmnOAVO> maxSozaiym = getMaxSozaiYm(tbj18Vo.getDCARCD(), tbj43VoList.get(0).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                //if(tbj43VoList.size() > 0){
                if(tbj43VoList.size() > 0){
                //素材年月の最大値取得
                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiym = getMaxSozaiYm(tbj18Vo.getDCARCD(), tbj43VoList.get(0).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                /** 2016/05/30 HDX不具合 HLC K.Soga MOD End */
                    Tbj43SozaiKanriListCmnOAVO tbj43Vo = new Tbj43SozaiKanriListCmnOAVO();
                    tbj43Vo.setDCARCD(tbj20Vo.getDCARCD());
                    tbj43Vo.setUPDAPL(tbj20Vo.getUPDAPL());
                    tbj43Vo.setUPDID(tbj20Vo.getUPDID());
                    tbj43Vo.setUPDNM(tbj20Vo.getUPDNM());
                    tbj43Vo.setCMCD(tbj20Vo.getCMCD());
                    tbj43Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                    tbj43Vo.setRECNO(tbj20Vo.getRECNO());
                    if(maxSozaiym.get(0).getSOZAIYM() != null){
                        tbj43Vo.setSOZAIYM(maxSozaiym.get(0).getSOZAIYM());
                        MaxSozaiYm = tbj43Vo.getSOZAIYM();
                    }else{
                        tbj43Vo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                    }
                    tbj43Dao.updateTempMaterial(tbj43Vo);
                }
                //素材一覧ログのHISTORYNO取得
                List<Tbj26LogSozaiKanriListVO> tbj26VoList = getMaxHistoryNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);
                if(tbj26VoList.size() > 0 && tbj43VoList.size() > 0){
                    //素材一覧ログ(共通)
                    Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                    tbj44Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                    tbj44Vo.setCMCD(tbj20Vo.getCMCD());
                    tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                    tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP_TO_ACTUAL);
                    tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                    regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);

                    //素材一覧(共有OA期間)ログ
                    Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                    tbj45Vo.setSOZAIYM(MaxSozaiYm);
                    tbj45Vo.setCMCD(tbj20Vo.getCMCD());
                    tbj45Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                    tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP_TO_ACTUAL);
                    tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                    tbj45Vo.setRECNO(tbj43VoList.get(0).getRECNO());
                    regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                }

                //素材一覧(共通OA期間)更新：RecNoがNULLのレコードのみが更新対象
                if(!flg){
                    List<Tbj43SozaiKanriListCmnOAVO> RecNoIsNullVoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NULL);
                    for(int j =0; j < RecNoIsNullVoList.size(); j++){
                        //素材年月の最大値取得
                        List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm = getMaxSozaiYm(tbj20Vo.getDCARCD(), RecNoIsNullVoList.get(j).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                        if(maxSozaiYm.get(0).getSOZAIYM() != null){
                            tbj43Cond.setSozaiym(maxSozaiYm.get(0).getSOZAIYM());
                        }else{
                            tbj43Cond.setSozaiym(RecNoIsNullVoList.get(j).getSOZAIYM());
                        }
                        tbj43Cond.setDcarcd(tbj18Vo.getDCARCD());
                        tbj43Cond.setCmcd(tbj20Vo.getCMCD());
                        tbj43Cond.setUpdapl(tbj20Vo.getUPDAPL());
                        tbj43Cond.setUpdid(tbj20Vo.getUPDID());
                        tbj43Cond.setUpdnm(tbj20Vo.getUPDNM());
                        updateMaterialListCmnOADao.RegisterCmCd(tbj43Cond);
                    }
                    flg = true;
                }
                /** 2016/03/14 HDX対応 HLC K.Soga ADD End */
            }

            // 割付済仮素材更新
            List<UsedRdProgramMaterialVO> usedRdTempMaterialList = materialRegisterDao.findUsedRdProgramTempMaterial(cond);

            if (usedRdTempMaterialList == null || usedRdTempMaterialList.size() == 0) {
                continue;
            }

            for (UsedRdProgramMaterialVO UsedRdProgramMaterialVO : usedRdTempMaterialList) {
                UsedRdProgramMaterialVO.setCMCD(newNo);
                materialRegisterDao.updateSQLUsedRdProgramTempMaterial(UsedRdProgramMaterialVO);
            }
        }

        //最新更新日時
        Date updDate = null;
        //車種変換カウント
        int carConvCnt = 0;
        //車種変換マスタ更新VO
        Mbj38CarConvertVO mbj38Vo = new Mbj38CarConvertVO();

        if (tbj20CarConvertVoList.size() != 0) {

            //車種変換マスタ更新VOリスト全件ループ処理
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20CarConvertVoList) {

                //ラジオの場合
                if(tbj20Vo.getTEMPCMCD().substring(0, 1).equals(HAMConstants.TEMPCMCODE_NOKBN_RADIO)){
                    continue;
                }

                if (updDate == null) {
                    mbj38Vo = ContractMaterialUtil.getCarConvertUpdateVo(tbj20Vo);
                    updDate = tbj20Vo.getUPDDATE();
                }

                //最新更新日時＜素材一覧の更新日時の場合
                if (updDate.compareTo(tbj20Vo.getUPDDATE()) < 0) {
                    mbj38Vo = ContractMaterialUtil.getCarConvertUpdateVo(tbj20Vo);
                    updDate = tbj20Vo.getUPDDATE();
                }

                carConvCnt = carConvCnt + 1;
            }

            if (!(carConvCnt == 0)){
                //車種変換マスタ削除処理
                Mbj38CarConvertDAO mbj38Dao = Mbj38CarConvertDAOFactory.createMbj38CarConvertDAO();
                mbj38Dao.deleteByMonth(mbj38Vo);

                //車種変換マスタ追加処理
                materialRegisterDao.insertCarConvert(mbj38Vo);
            }
        }

        return result;
    }
    /** 2015/11/10 JASRAC対応 HLC S.Fujimoto ADD End */

    /**
     * CMコード発行書出力画面の初期化用に、素材登録一覧及びマスタを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialRegisterResult getInitCmCodeIssueDocsList(MaterialRegisterCondition cond) throws HAMException {

        MaterialRegisterResult result = new MaterialRegisterResult();

        //コードマスタ取得準備
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        //コードタイプ＝「06」（固定）
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANY);
        //コードマスタを取得
        List<Mbj12CodeVO> codeList = codeDao.selectVO(codeCond);
        result.setCodeList(codeList);

        //部署マスタ取得準備
        Mbj32DepartmentDAO depDao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();
        Mbj32DepartmentCondition depCond = new Mbj32DepartmentCondition();
        //データ種別：「00」固定
        depCond.setDatatype("00");
        //出力フラグ：「1」固定(以上二つの条件でユニークになるとのこと)
        depCond.setOutputflg("1");
        List<Mbj32DepartmentVO> depList = depDao.selectVO(depCond);
        result.setDepList(depList);

        //素材情報の取得
        MaterialRegisterDAO dao = MaterialRegisterDAOFactory.createFindMaterialListDao();
        List<CmCodeIssueDocsVO> materialList = dao.findCmCodeIssueDocsListByCondition(cond);
        result.setCmCodeIssueDocsVOList(materialList);

        return result;
    }

    /**
     * 素材エンコード表用に、素材情報を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialRegisterResult findMaterialEncodeList(MaterialEncodeListCondition cond) throws HAMException {

        MaterialRegisterResult result = new MaterialRegisterResult();

        //素材エンコード表データの取得
        MaterialRegisterDAO dao = MaterialRegisterDAOFactory.createFindMaterialListDao();
        List<MaterialEncodeListVO> encodeList = dao.findMaterialEncodeListByCondition(cond);
        result.setMaterialEncodeList(encodeList);

        return result;
    }

    /**
     * 素材登録ログ用VOを取得します
     * @param vo
     * @param actionName
     * @return
     */
    private Tbj25LogSozaiKanriDataVO getMaterialRegisterLogVo(Tbj18SozaiKanriDataVO vo,String historyKbn) {

        Tbj25LogSozaiKanriDataVO ret = new Tbj25LogSozaiKanriDataVO();
        ret.setNOKBN(vo.getNOKBN());
        ret.setCMCD(vo.getCMCD());
        ret.setHISTORYKBN(historyKbn);
        return ret;
    }

    /** 2015/11/11 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮素材追加
     * @param vo 素材登録 登録実行時の登録データ
     * @param ctrtNoMap
     * @throws HAMException
     */
    private void regTempSozai(RegisterMaterialVO vo, Map<String, String> ctrtNoMap) throws HAMException {

        //仮素材発番最大値取得
        Tbj15CmCodeDAO tbj15Dao = Tbj15CmCodeDAOFactory.createTbj15CmCodeDAO();
        Tbj15CmCodeCondition tbj15Cond = new Tbj15CmCodeCondition();

        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj40TempSozaiContentDAO tbj40Dao = Tbj40TempSozaiContentDAOFactory.createTbj40TempSozaiContentDAO();
        MaterialRegisterDAO materialRegisterDao = MaterialRegisterDAOFactory.createFindMaterialListDao();

        //仮CMコードと採番したCMコードを紐づける
        Map<String, String> newCmCdMap = new HashMap<String, String>();

        //仮素材追加分ループ
        for (int i = 0; i < vo.getTbj36InsVo().size(); i++) {

            BigDecimal maxNo = null;
            String newNo = null;

            //タイム
            if (vo.getTbj36InsVo().get(i).getNOKBN().equals(HAMConstants.NOKBN_TIME)) {
                tbj15Cond.setNokbn(HAMConstants.TEMP_NOKBN_TIME);
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);
                maxNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));

                //自動採番更新
                tbj15Vo.setEXISTNO(maxNo);
                tbj15Vo.setUPDNM(vo.getTbj36InsVo().get(i).getUPDNM());
                tbj15Vo.setUPDAPL(vo.getTbj36InsVo().get(i).getUPDAPL());
                tbj15Vo.setUPDID(vo.getTbj36InsVo().get(i).getUPDID());
                tbj15Dao.updateVO(tbj15Vo);

                newNo = HAMConstants.TEMPCMCODE_NOKBN_TIME + String.format("%1$05d", maxNo.intValue());
            }
            //スポット
            else if (vo.getTbj36InsVo().get(i).getNOKBN().equals(HAMConstants.NOKBN_SPOT)) {
                tbj15Cond.setNokbn(HAMConstants.TEMP_NOKBN_SPOT);
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);
                maxNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));

                //自動採番更新
                tbj15Vo.setEXISTNO(maxNo);
                tbj15Vo.setUPDNM(vo.getTbj36InsVo().get(i).getUPDNM());
                tbj15Vo.setUPDAPL(vo.getTbj36InsVo().get(i).getUPDAPL());
                tbj15Vo.setUPDID(vo.getTbj36InsVo().get(i).getUPDID());
                tbj15Dao.updateVO(tbj15Vo);

                newNo = HAMConstants.TEMPCMCODE_NOKBN_SPOT + String.format("%1$05d", maxNo.intValue());
            }
            //ラジオ
            else if (vo.getTbj36InsVo().get(i).getNOKBN().equals(HAMConstants.NOKBN_RADIO)) {
                tbj15Cond.setNokbn(HAMConstants.TEMP_NOKBN_RADIO);
                Tbj15CmCodeVO tbj15Vo = tbj15Dao.selectVO(tbj15Cond).get(0);
                maxNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));

                //自動採番更新
                tbj15Vo.setEXISTNO(maxNo);
                tbj15Vo.setUPDNM(vo.getTbj36InsVo().get(i).getUPDNM());
                tbj15Vo.setUPDAPL(vo.getTbj36InsVo().get(i).getUPDAPL());
                tbj15Vo.setUPDID(vo.getTbj36InsVo().get(i).getUPDID());
                tbj15Dao.updateVO(tbj15Vo);

                newNo = HAMConstants.TEMPCMCODE_NOKBN_RADIO + String.format("%1$05d", maxNo.intValue());
            }

            //仮素材
            Tbj36TempSozaiKanriDataVO tbj36Vo = new Tbj36TempSozaiKanriDataVO();
            tbj36Vo = vo.getTbj36InsVo().get(i);

            //既にセットされている仮番号をキーとして採番した番号を保持
            newCmCdMap.put(tbj36Vo.getTEMPCMCD(), newNo);

            tbj36Vo.setTEMPCMCD(String.valueOf(newNo));
            tbj36Dao.insertVO(tbj36Vo);

            //仮素材登録変更ログ
            Tbj41LogTempSozaiKanriDataVO tbj41Vo = new Tbj41LogTempSozaiKanriDataVO();
            tbj41Vo.setNOKBN(tbj36Vo.getNOKBN());
            tbj41Vo.setTEMPCMCD(String.valueOf(newNo));
            tbj41Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP);
            materialRegisterDao.insertTempMaterialRegisterLog(tbj41Vo);
        }

        //素材契約紐付け情報
        if (vo.getTbj40InsVo() != null) {
            for (Tbj40TempSozaiContentVO Tbj40Vo : vo.getTbj40InsVo()) {

                //10桁CMコードが6桁の場合
                if(!(Tbj40Vo.getTEMPCMCD().length() == HAMConstants.TEMPMATERIAL_LENGTH)){
                    //契約コード
                    if (ctrtNoMap.containsKey(Tbj40Vo.getCTRTKBN() + "|" + Tbj40Vo.getCTRTNO())) {
                        Tbj40Vo.setCTRTNO(ctrtNoMap.get(Tbj40Vo.getCTRTKBN() + "|" + Tbj40Vo.getCTRTNO()));
                    }
                    //10桁CMコード
                    if (newCmCdMap.containsKey(Tbj40Vo.getTEMPCMCD())) {
                        Tbj40Vo.setTEMPCMCD(newCmCdMap.get(Tbj40Vo.getTEMPCMCD()));
                    }

                    tbj40Dao.insertVO(Tbj40Vo);
                }
            }
        }
    }

    /**
     * 仮素材更新
     * @param vo 素材登録 登録実行時の登録データ
     * @throws HAMException
     */
    private void updTempSozai(RegisterMaterialVO vo, Map<String, String> ctrtNoMap, List<Tbj20SozaiKanriListVO> tbj20CarConvertVoList) throws HAMException {

        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj40TempSozaiContentDAO tbj40Dao = Tbj40TempSozaiContentDAOFactory.createTbj40TempSozaiContentDAO();
        Tbj42SozaiKanriListCmnDAO tbj42Dao = Tbj42SozaiKanriListCmnDAOFactory.createTbj42SozaiKanriListCmnDAO();
        MaterialRegisterDAO materialRegisterDao = MaterialRegisterDAOFactory.createFindMaterialListDao();
        /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
        Tbj43SozaiKanriListCmnOADAO tbj43Dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        RegisterLogMaterialListCmnDAO regLogMaterialListCmnDao = RegisterLogMaterialListCmnDAOFactory.createLogMaterialListCmnDAO();
        RegisterLogMaterialListCmnOADAO regLogMaterialListCmnOADao = RegisterLogMaterialListCmnOADAOFactory.createLogMaterialListCmnOADAO();
        UpdateMaterialListCmnDAO updateMaterialListCmnDao = UpdateMaterialListCmnDAOFactory.createUpdateMaterialListCmnDAO();
        UpdateMaterialListCmnOADAO updateMaterialListCmnOADao = UpdateMaterialListCmnOADAOFactory.createUpdateMaterialListCmnOADAO();
        /** 2016/03/10 HDX対応 HLC K.Soga ADD End */

        //仮CMコードと採番したCMコードを紐づける
        Map<String, String> newCmCdMap = new HashMap<String, String>();

        for (int i = 0; i < vo.getTbj36UpdVo().size(); i++) {

            //仮素材更新
            Tbj36TempSozaiKanriDataVO tbj36Vo = new Tbj36TempSozaiKanriDataVO();
            tbj36Vo = vo.getTbj36UpdVo().get(i);

            //既にセットされている仮番号をキーとして採番した番号を保持
            newCmCdMap.put(tbj36Vo.getTEMPCMCD(), tbj36Vo.getTEMPCMCD());

            tbj36Dao.updateVO(tbj36Vo);

            //仮素材登録変更ログ
            Tbj41LogTempSozaiKanriDataVO tbj41Vo = new Tbj41LogTempSozaiKanriDataVO();
            tbj41Vo.setNOKBN(tbj36Vo.getNOKBN());
            tbj41Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
            tbj41Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
            materialRegisterDao.insertTempMaterialRegisterLog(tbj41Vo);

            //仮素材コンテンツの一括削除処理
            materialRegisterDao.deleteTempMaterialContentAll(tbj36Vo);

            //契約仮素材追加
            if (vo.getTbj40InsVo() != null) {
                for (int j = 0; j < vo.getTbj40InsVo().size(); j++) {
                    if (vo.getTbj40InsVo().get(j).getTEMPCMCD().equals(vo.getTbj36UpdVo().get(i).getTEMPCMCD())) {

                        //仮素材コンテンツ
                        Tbj40TempSozaiContentVO tbj40Vo = new Tbj40TempSozaiContentVO();
                        tbj40Vo = vo.getTbj40InsVo().get(j);

                        //仮番号が入っている場合は採番した値に置き換える
                        if (ctrtNoMap.containsKey(tbj40Vo.getCTRTKBN() + "|" + tbj40Vo.getCTRTNO())) {
                            tbj40Vo.setCTRTNO(ctrtNoMap.get(tbj40Vo.getCTRTKBN() + "|" + tbj40Vo.getCTRTNO()));
                        }

                        //契約仮素材紐付追加
                        tbj40Dao.insertVO(tbj40Vo);
                    }
                }
            }

            // 素材一覧更新
            MaterialRegisterCondition cond = new MaterialRegisterCondition();
            Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
            cond.setTempCmCd(tbj36Vo.getTEMPCMCD());
            List<Tbj20SozaiKanriListVO> tbj20VoList = materialRegisterDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_TEMP);

            /** 2016/03/31 HDX対応 HLC K.Soga ADD Start */
            //素材一覧(共通OA期間)更新用フラグ：RecNoがNULLのレコードのみが更新対象
            Boolean flg = false;
            /** 2016/03/31 HDX対応 HLC K.Soga ADD End */

            if (tbj20VoList == null) {
                continue;
            }
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {

                // 車種が変更されている場合
                if (!tbj36Vo.getDCARCD().equals(tbj20Vo.getDCARCD())) {
                    tbj36Vo.setDCARCD(tbj36Vo.getDCARCD());
                    tbj20Vo.setDCARCD(tbj36Vo.getDCARCD());
                    /** 2016/1/15 JASRAC不具合対応 HLC K.Soga ADD Start */
                    tbj20CarConvertVoList.add(tbj20Vo);
                    /** 2016/1/15 JASRAC不具合対応 HLC K.Soga ADD End */
                }
                else{
                    tbj20Vo.setDCARCD(null);
                }
                tbj20Vo.setTITLE(tbj36Vo.getTITLE());
                tbj20Vo.setSECOND(tbj36Vo.getSECOND());
                tbj20Vo.setLIMIT(tbj36Vo.getMLIMIT());
                /** 2016/03/23 HDX対応 HLC K.Soga DEL Start */
                //tbj20Vo.setSYATAN(tbj36Vo.getSYATAN());
                /** 2016/03/23 HDX対応 HLC K.Soga DEL End */
                tbj20Vo.setUPDNM(tbj36Vo.getUPDNM());
                tbj20Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                tbj20Vo.setUPDID(tbj36Vo.getUPDID());

                // 素材一覧の更新
                materialRegisterDao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_TEMP);

                /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
                //素材一覧のNEWNO(RECNO)取得
                tbj20Vo.setCMCD(tbj36Vo.getCMCD());
                tbj20Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                List<Tbj20SozaiKanriListVO> newNoVoList = getNewNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);

                //素材年月の最大値取得
                Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                tbj43Cond.setDcarcd(tbj36Vo.getDCARCD());
                tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                tbj43Cond.setReckbn(HAMConstants.MATERIAL_KBN_ACTUAL);
                List<Tbj43SozaiKanriListCmnOAVO> prevMaxSozaiYmList = tbj43Dao.findMaxSozaiYm(tbj43Cond);
                Date MaxSozaiYm = tbj20Vo.getSOZAIYM();
                if(prevMaxSozaiYmList.get(0).getSOZAIYM() != null){
                    MaxSozaiYm = prevMaxSozaiYmList.get(0).getSOZAIYM();
                }
                /** 2016/03/22 HDX対応 HLC K.Soga ADD End */

                //素材一覧変更ログ追加
                tbj26Vo.setDCARCD(tbj20Vo.getDCARCD());
                tbj26Vo.setCMCD(tbj36Vo.getCMCD());
                tbj26Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj26Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                tbj26Vo.setRECKBN(tbj20Vo.getRECKBN());
                /** 2016/03/10 HDX対応 HLC K.Soga MOD Start */
                //tbj26Vo.setRECNO(tbj20Vo.getRECNO());
                if(newNoVoList.size() > 0){
                    tbj26Vo.setRECNO(newNoVoList.get(0).getRECNO());
                }
                /** 2016/03/10 HDX対応 HLC K.Soga MOD End */
                materialRegisterDao.insertMaterialListLog(tbj26Vo);

                /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
                //素材一覧ログのHISTORYNO取得
                List<Tbj26LogSozaiKanriListVO> tbj26VoList = getMaxHistoryNo(tbj26Vo.getSOZAIYM(), tbj26Vo.getCMCD(), tbj26Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);

                //車種が変更されていない場合
                if(tbj20Vo.getDCARCD() == null){
                    if(tbj26VoList.size() > 0){
                        //素材一覧(共通)
                        Tbj42SozaiKanriListCmnCondition tbj42Cond = new Tbj42SozaiKanriListCmnCondition();
                        tbj42Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                        tbj42Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                        List<Tbj42SozaiKanriListCmnVO> tbj42VoList = tbj42Dao.selectVO(tbj42Cond);
                        for(int j = 0; j < tbj42VoList.size(); j++){
                            //素材一覧ログ(共通)
                            Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                            tbj44Vo.setSOZAIYM(tbj42VoList.get(j).getSOZAIYM());
                            tbj44Vo.setTEMPCMCD(tbj42VoList.get(j).getTEMPCMCD());
                            tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                            tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);
                        }
                        tbj43Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                        tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                        List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NOT_NULL);
                        for(int j = 0; j < tbj43VoList.size(); j++){
                            //素材一覧(共有OA期間)ログ
                            Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                            tbj45Vo.setDCARCD(tbj43VoList.get(j).getDCARCD());
                            tbj45Vo.setSOZAIYM(tbj43VoList.get(j).getSOZAIYM());
                            tbj45Vo.setRECKBN(tbj43VoList.get(j).getRECKBN());
                            tbj45Vo.setRECNO(tbj43VoList.get(j).getRECNO());
                            tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD Start */
                            tbj45Vo.setTEMPCMCD(tbj43VoList.get(j).getTEMPCMCD());
                            /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                            regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                        }
                    }
                //車種が変更されている場合
                }else{
                    if(newNoVoList.size() > 0 && tbj26VoList.size() > 0){
                        //素材年月の最大値取得
                        List<Tbj43SozaiKanriListCmnOAVO> prevmaxSozaiym = getMaxSozaiYm(tbj36Vo.getDCARCD(), tbj20Vo.getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                        MaxSozaiYm = tbj20Vo.getSOZAIYM();
                        if(prevmaxSozaiym.get(0).getSOZAIYM() != null){
                            MaxSozaiYm = prevmaxSozaiym.get(0).getSOZAIYM();
                        }
                        //素材一覧(共通)
                        Tbj42SozaiKanriListCmnVO tbj42Vo = new Tbj42SozaiKanriListCmnVO();
                        tbj42Vo.setDCARCD(tbj36Vo.getDCARCD());
                        tbj42Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                        tbj42Vo.setUPDAPL(tbj20Vo.getUPDAPL());
                        tbj42Vo.setUPDID(tbj20Vo.getUPDID());
                        tbj42Vo.setCMCD(tbj36Vo.getCMCD());
                        tbj42Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                        tbj42Vo.setRECNO(newNoVoList.get(0).getRECNO());
                        updateMaterialListCmnDao.updateSQLMaterialListCmn(tbj42Vo, HAMConstants.MATERIAL_KBN_TEMP);

                        //素材一覧(共通OA期間)
                        tbj43Cond.setCmcd(tbj20Vo.getCMCD());
                        tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                        List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NOT_NULL);
                        if(tbj43VoList.size() > 0){
                            //素材年月の最大値取得
                            List<Tbj43SozaiKanriListCmnOAVO> maxSozaiymList = getMaxSozaiYm(tbj20Vo.getDCARCD(), tbj43VoList.get(0).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                            Tbj43SozaiKanriListCmnOAVO tbj43Vo = new Tbj43SozaiKanriListCmnOAVO();
                            tbj43Vo.setDCARCD(tbj36Vo.getDCARCD());
                            tbj43Vo.setSOZAIYM(maxSozaiymList.get(0).getSOZAIYM());
                            tbj43Vo.setUPDAPL(tbj20Vo.getUPDAPL());
                            tbj43Vo.setUPDID(tbj20Vo.getUPDID());
                            tbj43Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                            tbj43Vo.setRECNO(newNoVoList.get(0).getRECNO());
                            if(maxSozaiymList.get(0).getSOZAIYM() != null){
                                tbj43Vo.setSOZAIYM(maxSozaiymList.get(0).getSOZAIYM());
                                MaxSozaiYm = tbj43Vo.getSOZAIYM();
                            }else{
                                tbj43Vo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                            }
                            updateMaterialListCmnOADao.updateSQLMaterialListCmnOA(tbj43Vo, HAMConstants.MATERIAL_KBN_TEMP);
                        }

                        //素材一覧ログ(共通)
                        Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                        tbj44Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                        tbj44Vo.setCMCD(tbj36Vo.getCMCD());
                        tbj44Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                        tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                        tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                        tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                        tbj44Vo.setRECNO(newNoVoList.get(0).getRECNO());
                        regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);

                        //素材一覧(共有OA期間)ログ
                        Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                        tbj45Vo.setSOZAIYM(MaxSozaiYm);
                        tbj45Vo.setDCARCD(tbj36Vo.getDCARCD());
                        tbj45Vo.setCMCD(tbj36Vo.getCMCD());
                        tbj45Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                        tbj45Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                        tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                        tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                        regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);

                        //素材一覧(共通OA期間)更新：RecNoがNULLのレコードのみが更新対象
                        if(!flg){
                            tbj43Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                            List<Tbj43SozaiKanriListCmnOAVO> RecNoIsNullVoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NULL);
                            for(int j =0; j < RecNoIsNullVoList.size(); j++){
                                //素材年月の最大値取得
                                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm = getMaxSozaiYm(tbj20Vo.getDCARCD(), RecNoIsNullVoList.get(j).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                                if(maxSozaiYm.get(0).getSOZAIYM() != null){
                                    tbj43Cond.setSozaiym(maxSozaiYm.get(0).getSOZAIYM());
                                }else{
                                    tbj43Cond.setSozaiym(RecNoIsNullVoList.get(j).getSOZAIYM());
                                }
                                tbj43Cond.setDcarcd(tbj20Vo.getDCARCD());
                                tbj43Cond.setUpdapl(tbj20Vo.getUPDAPL());
                                tbj43Cond.setUpdid(tbj20Vo.getUPDID());
                                tbj43Cond.setUpdnm(tbj20Vo.getUPDNM());
                                updateMaterialListCmnOADao.updateDcarCd(tbj43Cond);
                            }
                            flg = true;
                        }
                    }
                }
                /** 2016/03/10 HDX対応 HLC K.Soga ADD End */
            }
        }
    }

    /**
     * 仮素材削除
     * @param vo 素材登録 登録実行時の登録データ
     * @throws HAMException
     */
    private void deleteTempSozai(RegisterMaterialVO vo , List<Tbj20SozaiKanriListVO> tbj20CarConvertVoList) throws HAMException {

        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj41LogTempSozaiKanriDataDAO tbj41Dao = Tbj41LogTempSozaiKanriDataDAOFactory.createTbj41LogTempSozaiKanriDataDAO();
        /** 2016/03/11 HDX対応 HLC K.Soga ADD Start */
        Tbj42SozaiKanriListCmnDAO tbj42Dao = Tbj42SozaiKanriListCmnDAOFactory.createTbj42SozaiKanriListCmnDAO();
        Tbj43SozaiKanriListCmnOADAO tbj43Dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        Tbj44LogSozaiKanriListCmnDAO tbj44Dao = Tbj44LogSozaiKanriListCmnDAOFactory.createTbj44LogSozaiKanriListCmnDAO();
        /** 2016/03/11 HDX対応 HLC K.Soga ADD End */
        MaterialRegisterDAO materialRegisterDao = MaterialRegisterDAOFactory.createFindMaterialListDao();

        for (int i = 0; i < vo.getTbj36DelVo().size(); i++) {

            //仮素材登録変更ログ削除
            Tbj41LogTempSozaiKanriDataCondition tbj41Cond = new Tbj41LogTempSozaiKanriDataCondition();
            tbj41Cond.setNokbn(vo.getTbj36DelVo().get(i).getNOKBN());
            tbj41Cond.setTempcmcd(vo.getTbj36DelVo().get(i).getTEMPCMCD());
            List<Tbj41LogTempSozaiKanriDataVO> tbj41VoList = tbj41Dao.selectVO(tbj41Cond);
            for (Tbj41LogTempSozaiKanriDataVO tbj41Vo : tbj41VoList){
                tbj41Dao.deleteVO(tbj41Vo);
            }

            //仮素材削除
            Tbj36TempSozaiKanriDataVO tbj36Vo = new Tbj36TempSozaiKanriDataVO();
            tbj36Vo = vo.getTbj36DelVo().get(i);
            tbj36Dao.deleteVO(tbj36Vo);

            //仮素材コンテンツの一括削除処理
            materialRegisterDao.deleteTempMaterialContentAll(tbj36Vo);

            //素材一覧
            MaterialRegisterCondition cond = new MaterialRegisterCondition();
            cond.setTempCmCd(vo.getTbj36DelVo().get(i).getTEMPCMCD());
            List<Tbj20SozaiKanriListVO> tbj20VoList = materialRegisterDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_TEMP);

            if (tbj20VoList == null) {
                continue;
            }
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                // 素材一覧削除
                tbj20Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                materialRegisterDao.deleteMaterialListAll(tbj20Vo);

                //素材一覧変更ログ追加
                Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                tbj26Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                materialRegisterDao.deleteMaterialListLog(tbj26Vo);

                /** 2016/03/11 HDX対応 HLC K.Soga ADD Start */
                //素材一覧(共有)削除
                Tbj42SozaiKanriListCmnVO tbj42Vo = new Tbj42SozaiKanriListCmnVO();
                tbj42Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj42Dao.deleteVO(tbj42Vo);

                //素材一覧(共有)ログ削除
                Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                tbj44Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj44Dao.deleteVO(tbj44Vo);

                //素材一覧(共有OA期間)更新
                Tbj43SozaiKanriListCmnOAVO tbj43Vo = new Tbj43SozaiKanriListCmnOAVO();
                tbj43Vo.setDELFLG(HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE);
                tbj43Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj43Vo.setUPDNM(tbj36Vo.getUPDNM());
                tbj43Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                tbj43Vo.setUPDID(tbj36Vo.getUPDID());
                tbj43Dao.updateDelFlg(tbj43Vo);
                /** 2016/03/11 HDX対応 HLC K.Soga ADD End */
            }

            /** 2016/1/15 JASRAC不具合対応 HLC K.Soga ADD Start */
            //車種変換マスタ更新用VOリストに追加
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {

                /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD Start */
                tbj20Vo.setUPDNM(tbj36Vo.getUPDNM());
                tbj20Vo.setUPDID(tbj36Vo.getUPDID());
                tbj20Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD End */

                tbj20CarConvertVoList.add(tbj20Vo);
                /** 2016/1/15 JASRAC不具合対応 HLC K.Soga ADD End */
            }
        }
    }
    /** 2015/11/11 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 排他チェック(新対象行が更新可能かどうか判定します)
     * @param vo
     * @return
     * @throws HAMException
     */
    private boolean isExclusionForMaterialContent(RegisterMaterialVO vo) throws HAMException {

        //素材管理(排他チェック対象のデータを一つのリストにまとめる)
        List<Tbj18SozaiKanriDataVO> realMaterialLst = new ArrayList<Tbj18SozaiKanriDataVO>();

        //更新リスト
        if (vo.getUpdVOList() != null) {
            realMaterialLst.addAll(vo.getUpdVOList());
        }

        //削除リスト
        if (vo.getDelVOList() != null) {
            realMaterialLst.addAll(vo.getDelVOList());
        }

        //本素材情報リストが1件以上存在する場合
        if (realMaterialLst != null && realMaterialLst.size() > 0) {

            //排他チェック対象のデータの最新の状態を取得する
            Tbj18SozaiKanriDataDAO sozaiKanriDao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();
            List<Tbj18SozaiKanriDataVO> lockDatas = sozaiKanriDao.selectByMultiPk(realMaterialLst);

            //取得した最新データと検索時点の情報を比較して検索時より後に更新されていないかチェック
            //取得したデータをMapへ格納しなおす
            Map<String, Date> tempVoMap = new HashMap<String, Date>();
            for (Tbj18SozaiKanriDataVO lockData : lockDatas) {
                tempVoMap.put(getKeyForSozaiKanriData(lockData), lockData.getUPDDATE());
            }

            for (Tbj18SozaiKanriDataVO tbj18SozaiKanriData : realMaterialLst) {

                //取得したデータの中に更新しようとしているデータがなければ排他エラー
                if (!tempVoMap.containsKey(getKeyForSozaiKanriData(tbj18SozaiKanriData))) {
                    return false;
                }

                //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                if (tbj18SozaiKanriData.getUPDDATE().before(tempVoMap.get(getKeyForSozaiKanriData(tbj18SozaiKanriData)))) {
                    return false;
                }
            }
        }

        /** 2015/12/12 JASRAC対応 HLC K.Soga ADD Start */
        //更新・削除対象が存在しない場合、処理終了
        if ((vo.getTbj36UpdVo() == null || vo.getTbj36UpdVo().size() == 0)
                && (vo.getTbj36DelVo() == null || vo.getTbj36DelVo().size() == 0)) {
            return true;
        }

        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj36TempSozaiKanriDataCondition tbj36Cond = new Tbj36TempSozaiKanriDataCondition();


        //更新
        if (vo.getTbj36UpdVo() != null && vo.getTbj36UpdVo().size() != 0) {

            //比較用HashMap生成
            HashMap<String, Date> map = new HashMap<String, Date>();

            //更新対象全件ループ処理
            for (Tbj36TempSozaiKanriDataVO tbj36Vo : vo.getTbj36UpdVo()) {
                tbj36Cond.setTempcmcd(tbj36Vo.getTEMPCMCD());

                //再検索
                List<Tbj36TempSozaiKanriDataVO> tempMaterialList = tbj36Dao.selectVO(tbj36Cond);

                if (tempMaterialList != null && tempMaterialList.size() != 0) {
                    map.put(tempMaterialList.get(0).getTEMPCMCD(), tempMaterialList.get(0).getUPDDATE());
                } else {
                    //更新対象の仮10桁CMコードが存在しない場合、排他エラー
                    return false;
                }
            }

            //更新対象の仮10桁CMコードで更新日時を比較
            for (Tbj36TempSozaiKanriDataVO tbj36Vo : vo.getTbj36UpdVo()) {

                //更新対象の更新日時＜検索結果の更新日時の場合、排他エラー
                if (tbj36Vo.getUPDDATE().before(map.get(tbj36Vo.getTEMPCMCD()))) {
                    return false;
                }
            }
        }
        /** 2015/12/12 JASRAC対応 HLC K.Soga ADD End */

        //契約情報の排他チェック
        //排他チェック対象のデータを一つのリストにまとめる
        List<Tbj16ContractInfoVO> contractLst = new ArrayList<Tbj16ContractInfoVO>();
        if (vo.getUpdCntrctList() != null) {
            for (Tbj16ContractInfoUpdateVO tbj16ContractInfoUpdateVO : vo.getUpdCntrctList()) {
                Tbj16ContractInfoVO contractVo = new Tbj16ContractInfoVO();
                contractVo.setCTRTKBN(tbj16ContractInfoUpdateVO.getCTRTKBNOLD());
                contractVo.setCTRTNO(tbj16ContractInfoUpdateVO.getCTRTNO());
                contractVo.setUPDDATE(tbj16ContractInfoUpdateVO.getUPDDATE());
                contractLst.add(contractVo);
            }
        }

        if (vo.getDelCntrctList() != null) {
            for (Tbj16ContractInfoUpdateVO tbj16ContractInfoUpdateVO : vo.getDelCntrctList()) {
                Tbj16ContractInfoVO contractVo = new Tbj16ContractInfoVO();
                contractVo.setCTRTKBN(tbj16ContractInfoUpdateVO.getCTRTKBNOLD());
                contractVo.setCTRTNO(tbj16ContractInfoUpdateVO.getCTRTNO());
                contractVo.setUPDDATE(tbj16ContractInfoUpdateVO.getUPDDATE());
                contractLst.add(contractVo);
            }
        }

        if (contractLst != null && contractLst.size() > 0) {

            //排他チェック対象のデータの最新の状態を取得する
            Tbj16ContractInfoDAO contractDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
            List<Tbj16ContractInfoVO> contractDatas = contractDao.selectByPkWithLock(contractLst);

            //取得した最新データと検索時点の情報を比較して検索時より後に更新されていないかチェック
            //取得したデータをMapへ格納しなおす
            Map<String, Date> tempContractVoMap = new HashMap<String, Date>();
            for (Tbj16ContractInfoVO lockData : contractDatas) {
                tempContractVoMap.put(getKeyForCrContractInfo(lockData), lockData.getUPDDATE());
            }

            for (Tbj16ContractInfoVO tbj16ContractInfo : contractLst) {

                //取得したデータの中に更新しようとしているデータがなければ排他エラー
                if (!tempContractVoMap.containsKey(getKeyForCrContractInfo(tbj16ContractInfo))) {
                    return false;
                }

                //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                if (tbj16ContractInfo.getUPDDATE().before(tempContractVoMap.get(getKeyForCrContractInfo(tbj16ContractInfo)))) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(契約情報)
     * @param vo
     * @return
     */
    private String getKeyForSozaiKanriData(Tbj18SozaiKanriDataVO vo) {
        return vo.getNOKBN() + "|" + vo.getCMCD();
    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(契約情報)
     * @param vo
     * @return
     */
    private String getKeyForCrContractInfo(Tbj16ContractInfoVO vo) {
        return vo.getCTRTKBN() + "|" + vo.getCTRTNO();
    }

    /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
    /**
     * 素材一覧ログの作成番号(NEWNO)取得
     * @return 素材一覧ログリスト
     */
    private List<Tbj20SozaiKanriListVO> getNewNo(Date sozaiYm, String cmCd, String tempCmCd, String recKbn) throws HAMException {
        Tbj20SozaiKanriListDAO tbj20Dao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        Tbj20SozaiKanriListCondition tbj20Cond = new Tbj20SozaiKanriListCondition();
        tbj20Cond.setSozaiym(sozaiYm);
        tbj20Cond.setReckbn(recKbn);
        //本素材(仮素材⇒本素材)
        if(cmCd != null && tempCmCd != null){
            tbj20Cond.setCmcd(cmCd);
            tbj20Cond.setTempcmcd(tempCmCd);
        //本素材
        }else if(cmCd != null){
            tbj20Cond.setCmcd(cmCd);
        //仮素材
        } else if(tempCmCd != null){
            tbj20Cond.setTempcmcd(tempCmCd);
        }
        return tbj20Dao.FindNewNo(tbj20Cond);
    }

    /**
     * 素材一覧ログのHISTORYNO取得
     * @return 素材一覧ログリスト
     */
    private List<Tbj26LogSozaiKanriListVO> getMaxHistoryNo(Date sozaiym, String cmCd, String tempCmCd, String recKbn) throws HAMException {
        Tbj26LogSozaiKanriListDAO tbj26Dao = Tbj26LogSozaiKanriListDAOFactory.createTbj26LogSozaiKanriListDAO();
        Tbj26LogSozaiKanriListCondition tbj26Cond = new Tbj26LogSozaiKanriListCondition();
        tbj26Cond.setSozaiym(sozaiym);
        tbj26Cond.setReckbn(recKbn);
        //本素材(仮素材⇒本素材)
        if(cmCd != null && tempCmCd != null){
            tbj26Cond.setCmcd(cmCd);
            tbj26Cond.setTempcmcd(tempCmCd);
        //本素材
        }else if(cmCd != null){
            tbj26Cond.setCmcd(cmCd);
            tbj26Cond.setTempcmcd("");
        //仮素材
        } else if(tempCmCd != null){
            tbj26Cond.setCmcd("");
            tbj26Cond.setTempcmcd(tempCmCd);
        }
        return tbj26Dao.FindMaxHistoryNo(tbj26Cond);
    }

    /**
     * 素材年月の最大値取得
     * @param dcarCd 車種コード
     * @param sozaiYm 素材年月
     * @param materialKbn 素材区分
     * @return 素材一覧ログリスト
     */
    private List<Tbj43SozaiKanriListCmnOAVO> getMaxSozaiYm(String dcarCd, Date sozaiYm, String recKbn) throws HAMException {
        Tbj43SozaiKanriListCmnOADAO tbj43Dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
        tbj43Cond.setDcarcd(dcarCd);
        tbj43Cond.setSozaiym(sozaiYm);
        tbj43Cond.setReckbn(recKbn);
        return tbj43Dao.findMaxSozaiYm(tbj43Cond);
    }
    /** 2016/03/22 HDX対応 HLC K.Soga ADD End */

    /** 2015/2/17 素材登録不具合対応 HLC K.Soga DEL Start */
//    /**
//     * 車種変換マスタ用データを取得します
//     * @param sozaiKanriVo 削除/更新
//     * @param formatMonth 素材月
//     * @param formatYear 素材年
//     * @param basePhase フェーズの基準値
//     * @param carCnvDao 車種変換マスタ
//     * @param dao 素材一覧
//     * @throws HAMException エラーが発生した場合
//     */
//    private Mbj38CarConvertVO materialCarConv(Tbj20SozaiKanriListVO sozaiKanriVo,
//                                                DateFormat formatMonth,
//                                                DateFormat formatYear,
//                                                int basePhase,
//                                                Mbj38CarConvertDAO carCnvDao,
//                                                MaterialRegisterDAO dao) throws HAMException {
//
//        Mbj38CarConvertVO carConvYmVo = new Mbj38CarConvertVO();
//
//        //素材年月
//        carConvYmVo.setSOZAIYM(sozaiKanriVo.getSOZAIYM());
//        //データ更新者
//        carConvYmVo.setUPDNM(sozaiKanriVo.getUPDNM());
//        //更新プログラム
//        carConvYmVo.setUPDAPL(sozaiKanriVo.getUPDAPL());
//        //更新担当者ID
//        carConvYmVo.setUPDID(sozaiKanriVo.getUPDID());
//
//        //フェイズ基準値設定
//        int carConvPhase;
//        int month = Integer.parseInt(formatMonth.format(sozaiKanriVo.getSOZAIYM()));
//        int year = Integer.parseInt(formatYear.format(sozaiKanriVo.getSOZAIYM()));
//
//        //対象の月：1月～3月
//        if (month < HAMConstants.MONTH_APR) {
//            carConvPhase = year - basePhase - 1;
//        } else {
//            //対象の月：4月～12月
//            carConvPhase = year - basePhase;
//        }
//        carConvYmVo.setPHASE(BigDecimal.valueOf(carConvPhase));
//
//        return carConvYmVo;
//    }
    /** 2015/2/17 素材登録不具合対応 HLC K.Soga DEL End */
}
