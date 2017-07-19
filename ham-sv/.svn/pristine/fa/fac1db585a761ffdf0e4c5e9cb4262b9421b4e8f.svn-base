package jp.co.isid.ham.production.model;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj20CarCategoryVO;
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
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnCondition;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnDAO;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnDAOFactory;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnVO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOACondition;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOADAO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOADAOFactory;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;
import jp.co.isid.ham.common.model.Tbj44LogSozaiKanriListCmnVO;
import jp.co.isid.ham.common.model.Tbj45LogSozaiKanriListCmnOAVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * 素材一覧Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
 * ・HDX対応(2016/02/17 HLC K.Soga)<BR>
 * ・HDX不具合対応(2016/06/14 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListManager {

    /** シングルトン変数 */
    private static MaterialListManager _manager = new MaterialListManager();

    /** インスタンスを取得します */
    public static MaterialListManager getInstance() {
        return _manager;
    }

    private MaterialListManager() {
    }

    /**
     * 初期化用に素材登録一覧及びマスタを取得
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialListResult getInitMaterialList(MaterialListCondition cond) throws HAMException {

        //初期設定
        MaterialListResult result = new MaterialListResult();
        MaterialListDAO materialListDao = MaterialListDAOFactory.createFindMaterialListDao();
        Mbj12CodeDAO mbj12Dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();

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
        secCond.setSecuritycd("S000000103");
        secCond.setUsertype(cond.getUsertype());
        secVolist = secManager.getSecurityInfo(secCond).getSecurityInfo();
        result.setSecurityInfoVoList(secVolist);

        //コードマスタ(企業コード、New表示用)
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANY);
        List<Mbj12CodeVO> codeList = mbj12Dao.selectVO(codeCond);
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        codeCond.setCodetype(HAMConstants.CODETYPE_NEWDISP);
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        codeList.addAll(mbj12Dao.selectVO(codeCond));
        result.setCodeList(codeList);

        //カテゴリマスタ取得
        List<Mbj20CarCategoryVO> cateList =  materialListDao.findCategoryMstByCondition(cond);
        result.setCategoryList(cateList);

        //リスト内の車種マスタを取得
        List<MaterialCarMstVO> carList = materialListDao.findMaterialCarMstByCondition(cond);
        result.setCarList(carList);

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

        //素材情報リストの取得
        List<MaterialListVO> materialList = materialListDao.findMaterialListByCondition(cond);
        result.setMaterialList(materialList);

        //素材登録リストの取得
        /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
        //全件表示フラグがfalseの場合
        if(!cond.getDispAllList()){
            //現在から過去2年分のデータのみ取得
            cond.setDispAllListYmDate(DateUtil.addYear(DateUtil.toString(new Date()), -2));
        }
        /** 2016/04/12 HDX対応 HLC K.Soga ADD End */
        List<MaterialListVO> materialRegistList = materialListDao.findMaterialRegistByCondition(cond);
        result.setMaterialRegistList(materialRegistList);

        //契約情報リストの取得
        List<MaterialListCntrctVO> cntrctList = materialListDao.findMaterialListForCntrctByCondition(cond);
        result.setCntrctList(cntrctList);

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
     * 素材一覧と登録データを取得します
     * @param cond
     * @return
     */
    public MaterialListResult findMateriaRegisterList(MaterialListCondition cond)
        throws HAMException {

        MaterialListDAO materialListDao = MaterialListDAOFactory.createFindMaterialListDao();
        MaterialListResult result = findMaterialList(cond);

        //素材登録リストの取得
        /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
        //全件表示フラグがfalseの場合
        if(!cond.getDispAllList()){
            //現在から過去2年分のデータのみ取得
            cond.setDispAllListYmDate(DateUtil.addYear(DateUtil.toString(new Date()), -2));
        }
        /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
        List<MaterialListVO> materialRegistList = materialListDao.findMaterialRegistByCondition(cond);
        result.setMaterialRegistList(materialRegistList);

        return result;
    }

    /**
     * 素材一覧のデータを取得します
     * @param cond
     * @return
     */
    public MaterialListResult findMaterialList(MaterialListCondition cond)
        throws HAMException {

        MaterialListResult result = new MaterialListResult();
        MaterialListDAO materialListDao = MaterialListDAOFactory.createFindMaterialListDao();

        //素材情報リストの取得
        List<MaterialListVO> materialList = materialListDao.findMaterialListByCondition(cond);
        result.setMaterialList(materialList);

        return result;
    }

    /**
     * 素材一覧ログデータを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialListResult findLogMaterialList(MaterialListCondition cond)
        throws HAMException {

        MaterialListResult result = new MaterialListResult();
        MaterialListDAO materialListDao = MaterialListDAOFactory.createFindMaterialListDao();
        List<LogMaterialListVO> logList = materialListDao.findLogMaterialListByCondition(cond);
        result.setMaterialListLogList(logList);

        return result;
    }

    /**
     * 素材一覧情報を登録します
     * @param vo
     * @return
     */
    public MaterialListResult executeMaterialListInfo(RegisterMaterialListVO vo)
        throws HAMException {

        //排他制御
        if (!this.isExclusionForMaterialList(vo)){
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        //初期設定
        MaterialListDAO dao = MaterialListDAOFactory.createFindMaterialListDao();
        Tbj20SozaiKanriListDAO mateListDao =Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        /** 2016/02/24 HDX対応 HLC K.Soga ADD Start */
        Tbj42SozaiKanriListCmnDAO tbj42Dao =Tbj42SozaiKanriListCmnDAOFactory.createTbj42SozaiKanriListCmnDAO();
        Tbj43SozaiKanriListCmnOADAO tbj43Dao =Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        RegisterLogMaterialListCmnDAO regLogMaterialListCmnDao = RegisterLogMaterialListCmnDAOFactory.createLogMaterialListCmnDAO();
        RegisterLogMaterialListCmnOADAO regLogMaterialListCmnOADao = RegisterLogMaterialListCmnOADAOFactory.createLogMaterialListCmnOADAO();
        GetMaterialListCmnMaxSozaiYmDAO materialListCmnMaxSozaiYmDao = GetMaterialListCmnMaxSozaiYmDAOFactory.createGetMaterialListCmnMaxSozaiYmDAO();
        Calendar cal = Calendar.getInstance();
        /** 2016/02/24 HDX対応 HLC K.Soga ADD End */

        //本素材削除
        if (vo.getDelVOList() != null) {
            for (RegisterMaterialListUpdateVO delVo : vo.getDelVOList()) {

                //素材一覧
                delVo.setUPDDATE(new Date());
                mateListDao.updateVO(delVo);

                /** 2016/02/24 HDX対応 HLC K.Soga ADD Start */
                //素材一覧ログ
                Tbj26LogSozaiKanriListVO logVo = dao.getMaterialListLogVo(delVo,HAMConstants.HISTORYKBN_DELETE);
                dao.insertMaterialListLog(logVo);

                //素材一覧(共通)
                if (vo.getTbj42DelVOList() != null) {
                    for (Tbj42SozaiKanriListCmnVO tbj42DelVo : vo.getTbj42DelVOList()) {
                        //素材一覧、素材一覧(共通)の車種コード、作成番号が同一の場合
                        if(delVo.getDCARCD().equals(tbj42DelVo.getDCARCD()) && delVo.getRECNO().equals(tbj42DelVo.getRECNO())){
                            //素材一覧(共通)
                            tbj42Dao.updateVO(tbj42DelVo);
                        }
                    }
                }

                //素材一覧(共通OA企画)
                if (vo.getTbj43DelVOList() != null) {
                    for (Tbj43SozaiKanriListCmnOAVO tbj43DelVo : vo.getTbj43DelVOList()) {
                        //素材一覧、素材一覧(共通)の車種コード、作成番号が同一の場合
                        if(delVo.getDCARCD().equals(tbj43DelVo.getDCARCD()) && delVo.getRECNO().equals(tbj43DelVo.getRECNO())){
                            Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                            tbj43Cond.setDcarcd(tbj43DelVo.getDCARCD());
                            tbj43Cond.setReckbn(tbj43DelVo.getRECKBN());
                            tbj43Cond.setRecno(tbj43DelVo.getRECNO());
                            tbj43Cond.setCrtdate(tbj43DelVo.getCRTDATE());
                            //素材年月の秒数まで取得するために、素材一覧(OA期間)を再取得
                            List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.selectVO(tbj43Cond);
                            if(tbj43VoList.size() > 0){
                                tbj43DelVo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                                tbj43Dao.updateVO(tbj43DelVo);
                            }
                            break;
                        }
                    }
                }
                /** 2016/02/24 HDX対応 HLC K.Soga ADD End */
            }
        }

        //本素材追加
        MaterialListCondition cond = vo.getMaterialListCondition();
        if (vo.getRegVOList() != null) {

            //コピー登録処理
            if (cond.getCopyMode()) {
                Tbj26LogSozaiKanriListVO logVo = new Tbj26LogSozaiKanriListVO();
                logVo.setSOZAIYM(DateUtil.toDate(cond.getYmDate().concat("01")));
                logVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DELETE);
                dao.insertMaterialListLog(logVo);

                //指定したフェイズ年月全ての一覧を削除
                dao.deleteMaterialListSpecificYM(cond);
            }

            //通常登録処理
            for (RegisterMaterialListUpdateVO regVo : vo.getRegVOList()) {

                //素材一覧
                regVo.setRECNO(getRecNo(regVo));
                /** 2016/03/25 HDX対応 HLC K.Oki MOD Start */
                //mateListDao.insertVO(regVo);
                dao.registMaterialList(regVo);
                /** 2016/03/25 HDX対応 HLC K.Oki MOD END */

                //素材一覧ログ
                Tbj26LogSozaiKanriListVO tbj26Vo = dao.getMaterialListLogVo(regVo,HAMConstants.HISTORYKBN_REGSTER);
                dao.insertMaterialListLog(tbj26Vo);

                /** 2016/02/24 HDX対応 HLC K.Soga ADD Start */
                //素材一覧ログのHISTORYNO取得(tbj26の履歴番号でtbj44/45にInsert)
                List<Tbj26LogSozaiKanriListVO> tbj26VoList = getHistoryNo(regVo.getSOZAIYM(), regVo.getCMCD(), regVo.getTEMPCMCD(), tbj26Vo.getRECKBN());

                //素材一覧(共通)
                for (Tbj42SozaiKanriListCmnVO tbj42Vo : vo.getTbj42RegVOList()) {
                    //10桁CMコードが同一、且つ10桁コードがNULLでない、または、仮10桁CMコードが同一、且つ仮10桁コードがNULLでない場合
                    if((regVo.getCMCD().equals(tbj42Vo.getCMCD()) && regVo.getCMCD().length() != 0)
                            || (regVo.getTEMPCMCD().equals(tbj42Vo.getTEMPCMCD()) && regVo.getTEMPCMCD().length() != 0)){

                        //素材一覧(共通)
                        tbj42Vo.setRECNO(regVo.getRECNO());
                        tbj42Dao.insertVO(tbj42Vo);

                        //素材一覧(共有)ログ
                        if(tbj26VoList.size() > 0){
                            Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                            tbj44Vo.setDCARCD(regVo.getDCARCD().toString());
                            tbj44Vo.setSOZAIYM(tbj42Vo.getSOZAIYM());
                            tbj44Vo.setRECKBN(regVo.getRECKBN());
                            tbj44Vo.setRECNO(regVo.getRECNO());
                            tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGSTER);
                            tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);
                        }
                        break;
                    }
                }

                //素材一覧(共通OA期間)
                if (vo.getTbj43RegVOList() != null) {
                    for (Tbj43SozaiKanriListCmnOAVO tbj43Vo : vo.getTbj43RegVOList()) {
                        //素材一覧と素材一覧(共通OA期間)の10桁CMコードが同一、且つ10桁コードがNULLでない、または、仮10桁CMコードが同一、且つ仮10桁コードがNULLでない場合
                        if((regVo.getCMCD().equals(tbj43Vo.getCMCD()) && regVo.getCMCD().length() != 0)
                                || (regVo.getTEMPCMCD().equals(tbj43Vo.getTEMPCMCD()) && regVo.getTEMPCMCD().length() != 0)){

                            //素材一覧(共通OA期間)
                            Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                            tbj43Cond.setDcarcd(tbj43Vo.getDCARCD());
                            tbj43Cond.setReckbn(tbj43Vo.getRECKBN());
                            tbj43Cond.setSozaiym(DateUtil.toDate(cond.getYmDate().concat("01")));
                            tbj43Cond.setRecno(null);
                            tbj43Vo.setRECNO(regVo.getRECNO());
                            tbj43Vo.setSOZAIYM(DateUtil.toDate(cond.getYmDate().concat("01")));
                            if(tbj43Vo.getCMCD().length() > 0){
                                tbj43Cond.setCmcd(tbj43Vo.getCMCD());
                            }
                            if(tbj43Vo.getTEMPCMCD().length() > 0){
                                tbj43Cond.setTempcmcd(tbj43Vo.getTEMPCMCD());
                            }

                            //既にtbj43に該当の素材が存在するかどうかリストを取得する
                            List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findSozaiYm(tbj43Cond);

                            //更新(既に同じ年月に作成番号がNULLの素材が存在する場合)
                            if(tbj43VoList.size() > 0){

                                //素材一覧(共通OA期間)
                                tbj43Vo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                                /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD Start */
                                if(tbj43Vo.getOADATETERM().length() == 0){
                                    if(tbj43VoList.get(0).getOADATETERM().length() > 0){
                                        tbj43Vo.setOADATETERM(tbj43VoList.get(0).getOADATETERM());
                                    }
                                }
                                /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                                tbj43Dao.updateVO(tbj43Vo);

                            //新規追加(同じ年月に作成番号がNULLの素材が存在しない場合は追加処理)
                            }else{

                                //素材年月において、対象年月の秒数MAX + 1した値をDBに登録
                                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYmVoList = materialListCmnMaxSozaiYmDao.findMaxSozaiYm(tbj43Cond);

                                //取得した結果が1件以上の場合
                                if(maxSozaiYmVoList.size() > 0 && maxSozaiYmVoList.get(0).getSOZAIYM() != null){
                                    tbj43Vo.setSOZAIYM(maxSozaiYmVoList.get(0).getSOZAIYM());
                                }
                                tbj43Dao.insertVO(tbj43Vo);
                            }

                            //素材一覧(共有OA期間)ログ
                            if(tbj26VoList.size() > 0){
                                Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                                tbj45Vo.setDCARCD(regVo.getDCARCD().toString());
                                tbj45Vo.setSOZAIYM(tbj43Vo.getSOZAIYM());
                                tbj45Vo.setRECKBN(regVo.getRECKBN());
                                tbj45Vo.setRECNO(regVo.getRECNO());
                                /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD Start */
                                if(tbj43Vo.getCMCD().length() > 0){
                                    tbj45Vo.setCMCD(regVo.getCMCD());
                                }
                                /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                                if(tbj43Vo.getTEMPCMCD().length() > 0){
                                    tbj45Vo.setTEMPCMCD(tbj43Vo.getTEMPCMCD());
                                }
                                tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGSTER);
                                tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);

                                //素材一覧(共有OA期間)ログに当月+2か月分登録
                                //当月+1ヶ月登録処理
                                cal.setTime(tbj43Vo.getSOZAIYM());
                                cal.add(Calendar.MONTH, 1);
                                SimpleDateFormat sdf = new SimpleDateFormat("yyyyMM");
                                tbj43Cond.setSozaiym(DateUtil.toDate(sdf.format(cal.getTime()).concat("01")));
                                tbj43Vo.setRECNO(null);
                                if(tbj43Vo.getCMCD().length() > 0){
                                    tbj43Cond.setCmcd(tbj43Vo.getCMCD());
                                }else{
                                    tbj43Cond.setCmcd(null);
                                }
                                if(tbj43Vo.getTEMPCMCD().length() > 0){
                                    tbj43Cond.setTempcmcd(tbj43Vo.getTEMPCMCD());
                                }else{
                                    tbj43Cond.setTempcmcd(null);
                                }
                                tbj43Vo.setSOZAIYM(cal.getTime());
                                tbj43Vo.setOADATETERM(null);

                                //既にtbj43に該当の素材が存在するかどうかリストを取得する
                                List<Tbj43SozaiKanriListCmnOAVO> tbj43Month1VoList = tbj43Dao.findSozaiYm(tbj43Cond);
                                if(tbj43Month1VoList.size() < 1){
                                    //素材年月において、対象年月の秒数MAX + 1した値をDBに登録
                                    List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm1VoList = materialListCmnMaxSozaiYmDao.findMaxSozaiYm(tbj43Cond);
                                    if(maxSozaiYm1VoList.get(0).getSOZAIYM() != null){
                                        tbj43Vo.setSOZAIYM(maxSozaiYm1VoList.get(0).getSOZAIYM());
                                    }
                                    tbj43Dao.insertVO(tbj43Vo);
                                }

                                //当月+2ヶ月登録処理
                                cal.setTime(tbj43Vo.getSOZAIYM());
                                cal.add(Calendar.MONTH, 1);
                                tbj43Cond.setSozaiym(DateUtil.toDate(sdf.format(cal.getTime()).concat("01")));
                                tbj43Vo.setSOZAIYM(cal.getTime());
                                tbj43Vo.setOADATETERM(null);

                                //既にtbj43に該当の素材が存在するかどうかリストを取得する
                                List<Tbj43SozaiKanriListCmnOAVO> tbj43Month2VoList = tbj43Dao.findSozaiYm(tbj43Cond);
                                if(tbj43Month2VoList.size() < 1){
                                    //素材年月において、対象年月の秒数MAX + 1した値をDBに登録
                                    List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm2VoList = materialListCmnMaxSozaiYmDao.findMaxSozaiYm(tbj43Cond);
                                    if(maxSozaiYm2VoList.get(0).getSOZAIYM() != null){
                                        tbj43Vo.setSOZAIYM(maxSozaiYm2VoList.get(0).getSOZAIYM());
                                    }
                                    tbj43Dao.insertVO(tbj43Vo);
                                }
                            }
                            break;
                        }
                    }
                }
                /** 2016/02/24 HDX対応 HLC K.Soga ADD End */
            }
        }

        //更新
        if (vo.getUpdVOList() != null) {
            //素材一覧
            for (RegisterMaterialListUpdateVO updVo : vo.getUpdVOList()) {
                //素材一覧
                dao.updateMaterialList(updVo);

                //素材一覧ログ
                Tbj26LogSozaiKanriListVO tbj26Vo = dao.getMaterialListLogVo(updVo,HAMConstants.HISTORYKBN_UPDATE);
                dao.insertMaterialListLog(tbj26Vo);

                /** 2016/02/24 HDX対応 HLC K.Soga ADD Start */
                //素材一覧ログのHISTORYNO取得
                List<Tbj26LogSozaiKanriListVO> tbj26VoList = getHistoryNo(tbj26Vo.getSOZAIYM(), updVo.getCMCD(), updVo.getTEMPCMCD(), tbj26Vo.getRECKBN());
                if (vo.getTbj42UpdVOList() != null) {
                    //素材一覧(共通)
                    for (Tbj42SozaiKanriListCmnVO tbj42UpdVo : vo.getTbj42UpdVOList()) {
                        if(updVo.getDCARCD().equals(tbj42UpdVo.getDCARCD()) && updVo.getRECNO().equals(tbj42UpdVo.getRECNO())){

                            Tbj42SozaiKanriListCmnCondition tbj42Cond = new Tbj42SozaiKanriListCmnCondition();
                            tbj42Cond.setDcarcd(tbj42UpdVo.getDCARCD());
                            tbj42Cond.setSozaiym(tbj42UpdVo.getSOZAIYM());
                            tbj42Cond.setRecno(updVo.getRECNO());
                            tbj42Cond.setReckbn(updVo.getRECKBN());
                            tbj42Cond.setDelflg(updVo.getDELFLG());
                            if(tbj42UpdVo.getCMCD().length() > 0){
                                tbj42Cond.setCmcd(tbj42UpdVo.getCMCD());
                            }
                            if(tbj42UpdVo.getTEMPCMCD().length() > 0){
                                tbj42Cond.setTempcmcd(tbj42UpdVo.getTEMPCMCD());
                            }
                            List<Tbj42SozaiKanriListCmnVO> tbj42VoList = tbj42Dao.selectVO(tbj42Cond);
                            if(tbj42VoList.size() > 0){
                                //更新
                                tbj42Dao.updateVO(tbj42UpdVo);
                            }else{
                                //追加
                                tbj42Dao.insertVO(tbj42UpdVo);
                            }

                            //素材一覧(共有)ログ
                            Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                            tbj44Vo.setDCARCD(tbj42UpdVo.getDCARCD().toString());
                            tbj44Vo.setSOZAIYM(tbj42UpdVo.getSOZAIYM());
                            tbj44Vo.setRECKBN(tbj42UpdVo.getRECKBN());
                            tbj44Vo.setRECNO(tbj42UpdVo.getRECNO());
                            tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);
                            break;
                        }
                    }
                }
                if (vo.getTbj43UpdVOList() != null) {
                    //素材一覧(共通OA企画)
                    for (Tbj43SozaiKanriListCmnOAVO tbj43UpdVo : vo.getTbj43UpdVOList()) {
                        //素材一覧、素材一覧(共通)の車種コード、作成番号が同一の場合
                        if(updVo.getDCARCD().equals(tbj43UpdVo.getDCARCD()) && updVo.getRECNO().equals(tbj43UpdVo.getRECNO())){
                            //フォーマットの指定
                            SimpleDateFormat sdf = new SimpleDateFormat("yyyyMM");
                            Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                            tbj43Cond.setDcarcd(tbj43UpdVo.getDCARCD());
                            tbj43Cond.setReckbn(tbj43UpdVo.getRECKBN());
                            tbj43Cond.setRecno(tbj43UpdVo.getRECNO());
                            tbj43Cond.setSozaiym(DateUtil.toDate(sdf.format(tbj43UpdVo.getSOZAIYM()).concat("01")));
                            if(tbj43UpdVo.getCMCD().length() > 0){
                                tbj43Cond.setCmcd(tbj43UpdVo.getCMCD());
                            }
                            if(tbj43UpdVo.getTEMPCMCD().length() > 0){
                                tbj43Cond.setTempcmcd(tbj43UpdVo.getTEMPCMCD());
                            }
                            //素材年月の秒数まで取得するために、素材一覧(OA期間)を再取得
                            List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findSozaiYm(tbj43Cond);

                            if(tbj43VoList.size() == 0){
                                //追加
                                //素材年月において、対象年月の秒数MAX + 1した値をDBに登録
                                tbj43Cond.setSozaiym(DateUtil.toDate(cond.getYmDate().concat("01")));
                                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYmVoList = materialListCmnMaxSozaiYmDao.findMaxSozaiYm(tbj43Cond);
                                //取得した結果が1件以上の場合
                                if(maxSozaiYmVoList.size() > 0 && maxSozaiYmVoList.get(0).getSOZAIYM() != null)
                                {
                                    tbj43UpdVo.setSOZAIYM(maxSozaiYmVoList.get(0).getSOZAIYM());
                                }
                                tbj43Dao.insertVO(tbj43UpdVo);

                            }else{
                                //更新
                                tbj43UpdVo.setSOZAIYM(tbj43VoList.get(0).getSOZAIYM());
                                tbj43Dao.updateVO(tbj43UpdVo);
                            }

                            //素材一覧(共有OA期間)ログ
                            Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                            tbj45Vo.setDCARCD(tbj43UpdVo.getDCARCD().toString());
                            tbj45Vo.setSOZAIYM(tbj43UpdVo.getSOZAIYM());
                            tbj45Vo.setRECKBN(tbj43UpdVo.getRECKBN());
                            tbj45Vo.setRECNO(tbj43UpdVo.getRECNO());
                            tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                            /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD Start */
                            if(tbj43UpdVo.getCMCD().length() > 0){
                                tbj45Vo.setCMCD(tbj43UpdVo.getCMCD());
                            }
                            if(tbj43UpdVo.getTEMPCMCD().length() > 0){
                                tbj45Vo.setTEMPCMCD(tbj43UpdVo.getTEMPCMCD());
                            }
                            /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                            regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);

                            //素材一覧(共有OA期間)ログに当月+2か月分登録
                            //当月+1ヶ月登録処理
                            cal.setTime(tbj43UpdVo.getSOZAIYM());
                            cal.add(Calendar.MONTH, 1);
                            tbj43Cond.setSozaiym(DateUtil.toDate(sdf.format(cal.getTime()).concat("01")));
                            tbj43UpdVo.setRECNO(null);
                            if(tbj43UpdVo.getCMCD().length() > 0){
                                tbj43Cond.setCmcd(tbj43UpdVo.getCMCD());
                            }else{
                                tbj43Cond.setCmcd(null);
                            }
                            if(tbj43UpdVo.getTEMPCMCD().length() > 0){
                                tbj43Cond.setTempcmcd(tbj43UpdVo.getTEMPCMCD());
                            }else{
                                tbj43Cond.setTempcmcd(null);
                            }
                            tbj43UpdVo.setSOZAIYM(cal.getTime());
                            tbj43UpdVo.setOADATETERM(null);
                            List<Tbj43SozaiKanriListCmnOAVO> tbj43Month1VoList = tbj43Dao.findSozaiYm(tbj43Cond);

                            if(tbj43Month1VoList.size() < 1){
                                //素材年月において、対象年月の秒数MAX + 1した値をDBに登録
                                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm1VoList = materialListCmnMaxSozaiYmDao.findMaxSozaiYm(tbj43Cond);
                                if(maxSozaiYm1VoList.get(0).getSOZAIYM() != null){
                                    tbj43UpdVo.setSOZAIYM(maxSozaiYm1VoList.get(0).getSOZAIYM());
                                }
                                tbj43Dao.insertVO(tbj43UpdVo);
                            }

                            //当月+2ヶ月登録処理
                            cal.setTime(tbj43UpdVo.getSOZAIYM());
                            cal.add(Calendar.MONTH, 1);

                            tbj43Cond.setSozaiym(DateUtil.toDate(sdf.format(cal.getTime()).concat("01")));
                            tbj43UpdVo.setSOZAIYM(cal.getTime());
                            tbj43UpdVo.setOADATETERM(null);

                            List<Tbj43SozaiKanriListCmnOAVO> tbj43Month2VoList = tbj43Dao.findSozaiYm(tbj43Cond);

                            if(tbj43Month2VoList.size() < 1){
                                //素材年月において、対象年月の秒数MAX + 1した値をDBに登録
                                List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm2VoList = materialListCmnMaxSozaiYmDao.findMaxSozaiYm(tbj43Cond);
                                if(maxSozaiYm2VoList.get(0).getSOZAIYM() != null){
                                    tbj43UpdVo.setSOZAIYM(maxSozaiYm2VoList.get(0).getSOZAIYM());
                                }
                                tbj43Dao.insertVO(tbj43UpdVo);
                            }
                        }
                    }
                }
            }
            /** 2016/02/24 HDX対応 HLC K.Soga ADD End */
        }

        /** 2014/12/22 マスタ追加対応 HLC K.Soga DEL Start */
        ////一覧と登録データの同期
        //dao.mergeMaterialFromRegisterToList(cond);
        /** 2014/12/22 マスタ追加対応 HLC K.Soga DEL End */

        //車種変換マスタを更新(DELETE ⇒ INSERT)
        if(vo.getCarConvert() != null && !vo.getCarConvert().equals("")) {
            Mbj38CarConvertDAO carCnvDao = Mbj38CarConvertDAOFactory.createMbj38CarConvertDAO();
            Mbj38CarConvertVO carCnvVo = vo.getCarConvert();
            carCnvDao.deleteByMonth(carCnvVo);
            dao.insertCarConvert(carCnvVo);
        }

        return new MaterialListResult();
    }

    /**
     * 対象の作成番号を取得
     * @param regVo
     * @return
     * @throws HAMException
     */
    private String getRecNo(RegisterMaterialListUpdateVO regVo) throws HAMException {
        Tbj20SozaiKanriListDAO mateListDao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        Tbj20SozaiKanriListCondition regCond = new Tbj20SozaiKanriListCondition();
        regCond.setDcarcd(regVo.getDCARCD());
        regCond.setSozaiym(regVo.getSOZAIYM());
        regCond.setReckbn(regVo.getRECKBN());
        List<Tbj20SozaiKanriListVO> retList = mateListDao.findMaxRecNoByConditoin(regCond);

        return retList.size() <= 0 ? "0001" : retList.get(0).getRECNO();
    }

    /**
     * 更新対象行が更新可能かどうか判定します
     * @param vo
     * @return
     * @throws HAMException
     */
    private boolean isExclusionForMaterialList(RegisterMaterialListVO vo) throws HAMException {

        //素材一覧管理の排他チェック
        //排他チェック対象のデータを一つのリストにまとめる
        List<Tbj20SozaiKanriListVO> lst = new ArrayList<Tbj20SozaiKanriListVO>();

        if (vo.getDelVOList() != null) {
            lst.addAll(vo.getDelVOList());
        }
        if (vo.getUpdVOList() != null) {
            lst.addAll(vo.getUpdVOList());
        }

        if (lst != null && lst.size() > 0) {
            //排他チェック対象のデータの最新の状態を取得する
            Tbj20SozaiKanriListDAO sozaiListDao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
            List<Tbj20SozaiKanriListVO> lockDatas = sozaiListDao.selectByMultiPk(lst);

            //取得した最新データと検索時点の情報を比較して検索時より後に更新されていないかチェック
            //取得したデータをMapへ格納しなおす
            Map<String, Date> tempVoMap = new HashMap<String, Date>();
            for (Tbj20SozaiKanriListVO lockData : lockDatas) {
                tempVoMap.put(getKeyForSozaiKanriList(lockData), lockData.getUPDDATE());
            }
            for (Tbj20SozaiKanriListVO tbj20SozaiKanriList : lst) {
                //取得したデータの中に更新しようとしているデータがなければ排他エラー
                if (!tempVoMap.containsKey(getKeyForSozaiKanriList(tbj20SozaiKanriList))) {
                    return false;
                }
                //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                if (tbj20SozaiKanriList.getUPDDATE().before(tempVoMap.get(getKeyForSozaiKanriList(tbj20SozaiKanriList)))) {
                    return false;
                }
            }
        }

        //素材一覧管理の排他チェック(2)
        //排他チェック対象のデータを一つのリストにまとめる
        List<Tbj20SozaiKanriListVO> lst2 = new ArrayList<Tbj20SozaiKanriListVO>();

        if (vo.getRegVOList() != null) {
            lst2.addAll(vo.getRegVOList());
        }

        //登録データが1件以上存在する場合
        if (lst2 != null && lst2.size() > 0) {
            //排他チェック対象のデータの最新の状態を取得する
            Tbj20SozaiKanriListDAO sozaiListDao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();

            /** 2015/11/24 JASRAC対応 HLC K.Soga MOD Start */
            //List<Tbj20SozaiKanriListVO> lockDatas = sozaiListDao.selectByMultiCmCd(lst2);
            List<Tbj20SozaiKanriListVO> lockDatas = new ArrayList<Tbj20SozaiKanriListVO>();

            //登録データ分ループ処理
            for (int i = 0; i < lst2.size(); i++ )
            {
                if(lst2.get(i).getCMCD() != null) {
                    lockDatas = sozaiListDao.selectByMultiCmCd(lst2);
                }
            }
            /** 2015/11/24 JASRAC対応 HLC K.Soga MOD End */

            //登録しようとしているデータが既に存在していないかチェック
            if (lockDatas.size() > 0) {
                return false;
            }
        }

        return true;
    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(契約情報)
     * @param vo
     * @return
     */
    private String getKeyForSozaiKanriList(Tbj20SozaiKanriListVO vo) {
        SimpleDateFormat format = new SimpleDateFormat("yyyyMMddHHmmssSSS");
        return vo.getDCARCD() + "|" + format.format(vo.getSOZAIYM()) + "|" + vo.getRECKBN() +"|" + vo.getRECNO();
    }

    /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
    /**
     * 素材一覧ログのHISTORYNO取得
     * @return 素材一覧ログリスト
     */
    private List<Tbj26LogSozaiKanriListVO> getHistoryNo(Date sozaiym, String cmCd, String tempCmCd, String recKbn) throws HAMException {
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
    /** 2016/03/22 HDX対応 HLC K.Soga ADD End */
}