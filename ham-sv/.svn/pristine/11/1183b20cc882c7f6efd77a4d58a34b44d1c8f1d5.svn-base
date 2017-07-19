package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj05CarDAO;
import jp.co.isid.ham.common.model.Mbj05CarDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj38CarConvertDAO;
import jp.co.isid.ham.common.model.Mbj38CarConvertDAOFactory;
import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
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
import jp.co.isid.ham.production.util.KlimitUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * 契約情報登録起動時データ検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 JSE A.Naito)<BR>
 * ・JASRC対応(2015/11/30 HLC S.Fujimoto)<BR>
 * ・請求業務変更不具合対応(2016/03/22 HLC K.Soga)<BR>
 * ・HDX対応(2016/02/17 HLC K.Soga)<BR>
 * ・HDX不具合対応(2016/06/14 HLC K.Soga)<BR>
 * </P>
 *
 * @author
 */
public class ContractRegisterManager {

    /** シングルトンインスタンス */
    private static ContractRegisterManager _manager = new ContractRegisterManager();

    /** シングルトンの為、インスタンス化を禁止します */
    private ContractRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static ContractRegisterManager getInstance() {
        return _manager;
    }

    /**
     * 契約情報登録画面初期表示時取得テーブルリストを検索します
     *
     * @return ContractRegisterResult 汎用マスタ検索データ
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public ContractRegisterResult findByCondition(ContractRegisterCondition cond) throws HAMException {

        //検索結果
        ContractRegisterResult result = new ContractRegisterResult();
        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();

        //コードマスタの取得
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        List<Mbj12CodeVO> codeVoList = new ArrayList<Mbj12CodeVO>();
        Mbj12CodeCondition codeCondition = new Mbj12CodeCondition();
        codeCondition.setCodetype(HAMConstants.CODETYPE_CTRTKBN);
        codeVoList = codeDao.selectVO(codeCondition);
        codeCondition.setCodetype(HAMConstants.CODETYPE_COMPANY);
        codeVoList.addAll(codeDao.selectVO(codeCondition));
        result.setMbj12CodeVOList(codeVoList);

        //車種マスタの取得
        Mbj05CarDAO carDao = Mbj05CarDAOFactory.createMbj05CarDAO();
        //リスト内の車種マスタを取得
        result.setMbj05CarVOList(carDao.selectVO(new Mbj05CarCondition()));

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
        for (String securityCd : cond.getStrSecurityCdList()) {
            secCond.setSecuritycd(securityCd);
            secVolist.addAll(secManager.getSecurityInfo(secCond).getSecurityInfo());
        }
        result.setSecurityInfoVoList(secVolist);

        //画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO displayControlDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition displayControlCond = new Mbj37DisplayControlCondition();
        displayControlCond.setFormid(cond.getFormid());
        result.setMbj37DisplayControlVoList(displayControlDao.selectVO(displayControlCond));

        //一覧表示パターン取得
        Tbj30DisplayPatternDAO patternDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition displayPatternCond = new Tbj30DisplayPatternCondition();
        displayPatternCond.setHamid(cond.getHamid());
        displayPatternCond.setFormid(cond.getFormid());
        result.setTbj30DisplayPatternVoList(patternDao.selectVO(displayPatternCond));

        //契約情報テーブルの取得
        Tbj16ContractInfoDAO contractInfoDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
        Tbj16ContractInfoCondition contractInfoCond = new Tbj16ContractInfoCondition();
        contractInfoCond.setDelflg(" ");
        result.setTbj16ContractInfoVOList(contractInfoDao.selectVOForLIST(contractInfoCond));

        //使用素材表示用(タレント・ナレーター)データの取得
        result.setFindUseMaterialTalentVOList(contractRegisterDao.findUseMaterialTalentListByCondition());

        //使用素材表示用(楽曲)データの取得
        result.setFindUseMaterialMusicVOList(contractRegisterDao.findUseMaterialMusicListByCondition());

        //カテゴリリスト用データの取得
        result.setCategoryList(contractRegisterDao.getCategory());

        //秒数リスト用データの取得
        result.setSecondList(contractRegisterDao.getSecond());

        //車種担当リスト用データの取得
        result.setSyatanList(contractRegisterDao.getSyatan());

        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD Start */
        //ラジオ番組割付済み素材を取得
        Tbj38RdProgramMaterialDAO tbj38Dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj38RdProgramMaterialCondition tbj38Cond = new Tbj38RdProgramMaterialCondition();
        result.setRdPgmMaterialList(tbj38Dao.findUsedRdProgramMaterial(tbj38Cond));
        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD End */

        return result;
    }

    /**
     * 契約情報登録画面削除ボタン押下時取得テーブルリストを検索します
     *
     * @return ContractRegisterResult 汎用マスタ検索データ
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public ContractDeleteResult countByCondition(ContractDeleteCondition cond) throws HAMException {

        //検索結果
        ContractDeleteResult result = new ContractDeleteResult();
        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();

        //コンテンツテーブルのカウントの取得
        List<ContractDeleteCVO> contentCount = contractRegisterDao.countContentListByCondition(cond);
        result.setContractDeleteCVOList(contentCount);

        //楽曲の場合JASRACの登録有無チェック
        if (HAMConstants.CTRTKBN_MUSIC.equals(cond.getStrCtrtKbn())) {

            //JASRACテーブルのカウントの取得
            List<ContractDeleteJVO> jasracCount = contractRegisterDao.countJasracListByCondition(cond);
            result.setContractDeleteJVOList(jasracCount);
        }

        return result;
    }

    /**
     * 契約情報登録処理
     * @param vo 登録VO
     * @return 登録結果
     * @throws HAMException
     */
    public UpdateContractInfoResult updateByCondition(UpdateContractInfoVO vo) throws HAMException {

        //検索結果
        UpdateContractInfoResult result = new UpdateContractInfoResult();

        //排他チェック
        if (!checkExclusionForUpdateContractInfo(vo)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        /** 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
        /** 車種変換マスタ更新用VOリスト */
        List<Tbj20SozaiKanriListVO> tbj20CarConvertVoList = new ArrayList<Tbj20SozaiKanriListVO>();
        /** 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();
        MaterialRegisterDAO materialDao = MaterialRegisterDAOFactory.createFindMaterialListDao();
        Tbj17ContentDAO contDao = Tbj17ContentDAOFactory.createTbj17ContentDAO();

        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD Start */
        Tbj40TempSozaiContentDAO tbj40dao = Tbj40TempSozaiContentDAOFactory.createTbj40TempSozaiContentDAO();
        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD End */

        /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
        Tbj42SozaiKanriListCmnDAO tbj42Dao = Tbj42SozaiKanriListCmnDAOFactory.createTbj42SozaiKanriListCmnDAO();
        Tbj43SozaiKanriListCmnOADAO tbj43Dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        Tbj44LogSozaiKanriListCmnDAO tbj44Dao = Tbj44LogSozaiKanriListCmnDAOFactory.createTbj44LogSozaiKanriListCmnDAO();
        RegisterLogMaterialListCmnDAO regLogMaterialListCmnDao = RegisterLogMaterialListCmnDAOFactory.createLogMaterialListCmnDAO();
        RegisterLogMaterialListCmnOADAO regLogMaterialListCmnOADao = RegisterLogMaterialListCmnOADAOFactory.createLogMaterialListCmnOADAO();
        UpdateMaterialListCmnDAO updateMaterialListCmnDao = UpdateMaterialListCmnDAOFactory.createUpdateMaterialListCmnDAO();
        UpdateMaterialListCmnOADAO updateMaterialListCmnOADao = UpdateMaterialListCmnOADAOFactory.createUpdateMaterialListCmnOADAO();
        /** 2016/03/22 HDX対応 HLC K.Soga ADD End */

        //登録・更新・削除のデータをまとめたリスト.
        List<Tbj16ContractInfoUpdateVO> allContractInfoVoList = new ArrayList<Tbj16ContractInfoUpdateVO>();
        //仮契約番号と採番した契約番号を紐づける
        Map<String, String> ctrtNoMap = new HashMap<String, String>();
        //仮CMコードと採番したCMコードを紐づける
        Map<String, String> cmCdMap = new HashMap<String, String>();

        //契約情報テーブルのDelete（論理削除）
        if (vo.getTbj16ContractInfoUpdateVOListDel() != null) {
            for (int i = 0; i < vo.getTbj16ContractInfoUpdateVOListDel().size(); i++) {

                //履歴の登録
                Tbj24LogContractInfoVO logContractInfoVo = new Tbj24LogContractInfoVO();
                logContractInfoVo.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListDel().get(i).getCTRTKBN());
                logContractInfoVo.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListDel().get(i).getCTRTNO());
                logContractInfoVo.setHISTORYKBN(HAMConstants.HISTORYKBN_DELETE);
                contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);

                //契約情報テーブル,JASRACテーブルの論理削除
                Tbj16ContractInfoUpdateVO deleteVo = vo.getTbj16ContractInfoUpdateVOListDel().get(i);
                contractRegisterDao.deleteContractInfoCondition(deleteVo);
                contractRegisterDao.deleteJasracCondition(deleteVo);

                //コンテンツテーブル削除
                Tbj17ContentVO contCond = new Tbj17ContentVO();
                contCond.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListDel().get(i).getCTRTKBN());
                contCond.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListDel().get(i).getCTRTNO());
                contDao.deleteByVo(contCond);

                /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD Start */
                //仮素材契約紐付け情報全削除
                Tbj40TempSozaiContentVO tbj40Vo = new Tbj40TempSozaiContentVO();
                tbj40Vo.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListDel().get(i).getCTRTKBN());
                tbj40Vo.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListDel().get(i).getCTRTNO());
                tbj40dao.deleteByVo(tbj40Vo);
                /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD End */
            }

            allContractInfoVoList.addAll(vo.getTbj16ContractInfoUpdateVOListDel());
        }

        //契約情報テーブルのInsert
        if (vo.getTbj16ContractInfoUpdateVOListReg() != null) {
            for (int i = 0; i < vo.getTbj16ContractInfoUpdateVOListReg().size(); i++) {
                //契約コードのMAX値の検索
                String getCtrtNo = contractRegisterDao.searchCtrtNoByCondition(vo.getTbj16ContractInfoUpdateVOListReg().get(i));
                Tbj16ContractInfoUpdateVO insertVo = vo.getTbj16ContractInfoUpdateVOListReg().get(i);

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
                logContractInfoVo.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListReg().get(i).getCTRTKBN());
                logContractInfoVo.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListReg().get(i).getCTRTNO());
                logContractInfoVo.setHISTORYKBN("01");
                contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);
            }

            allContractInfoVoList.addAll(vo.getTbj16ContractInfoUpdateVOListReg());
        }

        //契約情報テーブルのUpdate
        if (vo.getTbj16ContractInfoUpdateVOListUpd() != null) {
            for (int i = 0; i < vo.getTbj16ContractInfoUpdateVOListUpd().size(); i++) {
                if (!vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTKBN().equals(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTKBNOLD())) {
                    //契約コードのMAX値の検索
                    String getCtrtNo = contractRegisterDao.searchCtrtNoByCondition(vo.getTbj16ContractInfoUpdateVOListUpd().get(i));
                    Tbj16ContractInfoUpdateVO updateVo = vo.getTbj16ContractInfoUpdateVOListUpd().get(i);

                    //既にセットされている仮番号をキーとして採番した番号を保持
                    ctrtNoMap.put(updateVo.getCTRTKBN() + "|" + updateVo.getCTRTNO(), getCtrtNo);
                    updateVo.setCTRTNONEW(getCtrtNo);
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
                    logContractInfoVo.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTKBN());
                    logContractInfoVo.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTNONEW());
                    logContractInfoVo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                    contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);
                } else {
                    Tbj16ContractInfoUpdateVO updateVo = vo.getTbj16ContractInfoUpdateVOListUpd().get(i);
                    updateVo.setCTRTNONEW(updateVo.getCTRTNO());
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
                    logContractInfoVo.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTKBN());
                    logContractInfoVo.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTNO());
                    logContractInfoVo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                    contractRegisterDao.insertHistoryForContractInfo(logContractInfoVo);
                }

                //コンテンツテーブル削除
                Tbj17ContentVO contCond = new Tbj17ContentVO();
                contCond.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTKBNOLD());
                contCond.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTNO());
                contDao.deleteByVo(contCond);

                /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD Start */
                //仮素材契約紐付け情報全削除
                Tbj40TempSozaiContentVO tbj40Vo = new Tbj40TempSozaiContentVO();
                tbj40Vo.setCTRTKBN(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTKBN());
                tbj40Vo.setCTRTNO(vo.getTbj16ContractInfoUpdateVOListUpd().get(i).getCTRTNO());
                tbj40dao.deleteByVo(tbj40Vo);
                /** 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD End */
            }

            allContractInfoVoList.addAll(vo.getTbj16ContractInfoUpdateVOListUpd());
        }

        //素材登録テーブルの更新(・登録・削除)
        //削除
        if (vo.getTbj18SozaiKanriDataVOListDel() != null) {
            Tbj18SozaiKanriDataDAO tbj18Dao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();

            for (Tbj18SozaiKanriDataVO tbj18Vo : vo.getTbj18SozaiKanriDataVOListDel()) {
                //素材登録ログ登録
                Tbj25LogSozaiKanriDataVO tbj25Vo = new Tbj25LogSozaiKanriDataVO();
                tbj25Vo.setNOKBN(tbj18Vo.getNOKBN());
                tbj25Vo.setCMCD(tbj18Vo.getCMCD());
                tbj25Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_DELETE);
                materialDao.insertMaterialRegisterLog(tbj25Vo);

                //素材登録
                tbj18Dao.deleteVO(tbj18Vo);

                //素材一覧
                MaterialRegisterCondition cond = new MaterialRegisterCondition();
                cond.setCmCd(tbj18Vo.getCMCD());
                List<Tbj20SozaiKanriListVO> tbj20VoList = materialDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_ACTUAL);

                /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
                if (tbj20VoList.size() != 0) {

                    //素材一覧更新
                    materialDao.updateDelMaterialList(tbj18Vo);

                    /** 2016/03/11 HDX対応 HLC K.Soga ADD Start */
                    for(int i = 0; i< tbj20VoList.size(); i++){
                        //素材一覧(共有)更新
                        Tbj42SozaiKanriListCmnVO tbj42Vo = new Tbj42SozaiKanriListCmnVO();
                        tbj42Vo.setDELFLG(HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE);
                        tbj42Vo.setCMCD(tbj18Vo.getCMCD());
                        if(tbj20VoList.get(i).getTEMPCMCD().length() > 0){
                            tbj42Vo.setTEMPCMCD(tbj20VoList.get(i).getTEMPCMCD());
                        }else{
                            tbj42Vo.setTEMPCMCD(null);
                        }
                        tbj42Vo.setUPDNM(tbj18Vo.getUPDNM());
                        tbj42Vo.setUPDAPL(tbj18Vo.getUPDAPL());
                        tbj42Vo.setUPDID(tbj18Vo.getUPDID());
                        tbj42Dao.updateDelFlg(tbj42Vo);

                        //素材一覧(共有OA期間)更新
                        Tbj43SozaiKanriListCmnOAVO tbj43Vo = new Tbj43SozaiKanriListCmnOAVO();
                        tbj43Vo.setDELFLG(HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE);
                        tbj43Vo.setCMCD(tbj18Vo.getCMCD());
                        if(tbj20VoList.get(i).getTEMPCMCD().length() > 0){
                            tbj43Vo.setTEMPCMCD(tbj20VoList.get(i).getTEMPCMCD());
                        }else{
                            tbj43Vo.setTEMPCMCD(null);
                        }
                        tbj43Vo.setUPDNM(tbj18Vo.getUPDNM());
                        tbj43Vo.setUPDAPL(tbj18Vo.getUPDAPL());
                        tbj43Vo.setUPDID(tbj18Vo.getUPDID());
                        tbj43Dao.updateDelFlg(tbj43Vo);
                    }
                    /** 2016/03/11 HDX対応 HLC K.Soga ADD End */
                }

                //車種変換マスタ更新用VOリストに追加
                for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                    tbj20CarConvertVoList.add(tbj20Vo);
                }

                //コンテンツテーブル削除
                Tbj17ContentVO tbj17Cond = new Tbj17ContentVO();
                tbj17Cond.setCMCD(tbj18Vo.getCMCD());
                contDao.deleteByVo(tbj17Cond);
            }
        }

        //更新
        if (vo.getTbj18SozaiKanriDataVOListUpd() != null) {
            Tbj18SozaiKanriDataDAO tbj18Dao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();
            for (Tbj18SozaiKanriDataVO tbj18Vo : vo.getTbj18SozaiKanriDataVOListUpd()) {
                //素材登録
                if (tbj18Vo.getSTATUS() != null && tbj18Vo.getSTATUS().equals("")) {
                    tbj18Vo.setSTATUS(" ");
                }
                tbj18Dao.updateVO(tbj18Vo);

                //素材登録ログ登録
                Tbj25LogSozaiKanriDataVO tbj25Vo = new Tbj25LogSozaiKanriDataVO();
                tbj25Vo.setNOKBN(tbj18Vo.getNOKBN());
                tbj25Vo.setCMCD(tbj18Vo.getCMCD());
                tbj25Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                materialDao.insertMaterialRegisterLog(tbj25Vo);

                //素材一覧
                MaterialRegisterCondition cond = new MaterialRegisterCondition();
                cond.setCmCd(tbj18Vo.getCMCD());
                List<Tbj20SozaiKanriListVO> tbj20VoList = materialDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_ACTUAL);

                /** 2016/03/31 HDX対応 HLC K.Soga ADD Start */
                //素材一覧(共通OA期間)更新用フラグ：RecNoがNULLのレコードのみが更新対象
                Boolean flg = false;
                /** 2016/03/31 HDX対応 HLC K.Soga ADD End */

                //車種の変更チェック
                if (tbj20VoList.size() <= 0) {
                    //素材一覧にデータがなければ何もしない
                } else {
                    for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                        //データ更新者
                        tbj20Vo.setUPDNM(tbj18Vo.getUPDNM());
                        //更新プログラム
                        tbj20Vo.setUPDAPL(tbj18Vo.getUPDAPL());
                        //更新担当者ID
                        tbj20Vo.setUPDID(tbj18Vo.getUPDID());
                        //タイトル
                        tbj20Vo.setTITLE(tbj18Vo.getTITLE());
                        //秒数
                        tbj20Vo.setSECOND(tbj18Vo.getSECOND());
                        //使用期限期間
                        tbj20Vo.setLIMIT(tbj18Vo.getMLIMIT());
                        //車種担当
                        tbj20Vo.setSYATAN(tbj18Vo.getSYATAN());

                        /** 2016/1/13 JASRAC不具合対応 HLC K.Oki MOD Start */
                        //if (tbj18SozaiKanriDataVO.getDCARCD().equals(adminVoList.get(0).getDCARCD())) {
                        //車種が変更されていない場合
                        if (tbj18Vo.getDCARCD().equals(tbj20Vo.getDCARCD())) {
                        /** 2016/1/13 JASRAC不具合対応 HLC K.Oki MOD End */

                            /** 2016/03/31 HDX対応 HLC K.Soga DEL Start */
                            ////年月→変更しないため、null指定
                            //tbj20Vo.setSOZAIYM(null);
                            /** 2016/03/31 HDX対応 HLC K.Soga DEL End */
                            //作成番号→変更しないため、null指定
                            tbj20Vo.setRECNO(null);
                            //車種コード→変更しないため、null指定
                            tbj20Vo.setDCARCD(null);

                            //素材一覧
                            materialDao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_ACTUAL);

                            //素材一覧ログ
                            Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                            tbj26Vo.setDCARCD(tbj20Vo.getDCARCD());
                            tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                            tbj26Vo.setRECKBN(tbj20Vo.getRECKBN());
                            tbj26Vo.setRECNO(tbj20Vo.getRECNO());
                            tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            /** 2016/03/23 HDX対応 HLC K.Soga ADD Start */
                            tbj26Vo.setCMCD(tbj20Vo.getCMCD());
                            tbj26Vo.setTEMPCMCD(tbj26Vo.getTEMPCMCD());
                            /** 2016/03/23 HDX対応 HLC K.Soga ADD End */
                            materialDao.insertMaterialListLog(tbj26Vo);

                            /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
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
                                tbj45Vo.setCMCD(tbj18Vo.getCMCD());
                                if(tbj43VoList.get(0).getTEMPCMCD().length() > 0){
                                    tbj45Vo.setTEMPCMCD(tbj43VoList.get(0).getTEMPCMCD());
                                }
                                /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                                regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                            }
                            /** 2016/03/22 HDX対応 HLC K.Soga ADD End */

                        //車種が変更されている場合
                        } else {
                            /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
                            //素材年月の最大値取得
                            List<Tbj43SozaiKanriListCmnOAVO> prevSozaiym = getMaxSozaiYm(tbj20Vo.getDCARCD(), tbj20Vo.getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                            Date MaxSozaiYm = tbj20Vo.getSOZAIYM();
                            if(prevSozaiym.get(0).getSOZAIYM() != null){
                                MaxSozaiYm = prevSozaiym.get(0).getSOZAIYM();
                            }
                            /** 2016/03/22 HDX対応 HLC K.Soga ADD End */

                            //車種コード
                            tbj20Vo.setDCARCD(tbj18Vo.getDCARCD());

                            //車種変換マスタ更新用VOリストに追加
                            tbj20CarConvertVoList.add(tbj20Vo);

                            //素材一覧
                            materialDao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_ACTUAL);

                            //素材一覧ログ
                            Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                            tbj26Vo.setDCARCD(tbj20Vo.getDCARCD());
                            /** 2014/10/30 マスタ追加対応 HLC K.Soga MOD Start */
                            //listLogVo.setDCARCD(updVo.getDCARCD());
                            //listLogVo.setRECKBN(updVo.getRECKBN());
                            //listLogVo.setRECNO(updVo.getRECNO());
                            tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                            tbj26Vo.setCMCD(tbj18Vo.getCMCD());
                            tbj26Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                            /** 2014/10/30 マスタ追加対応 HLC K.Soga MOD End */
                            tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                            materialDao.insertMaterialListLog(tbj26Vo);

                            /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
                            //素材一覧のNEWNO(RECNO)取得
                            if(tbj20Vo.getTEMPCMCD().length() >0){
                                tbj20Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                            }
                            else
                            {
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
                                    tbj44Vo.setCMCD(tbj18Vo.getCMCD());
                                    tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                                    tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                                    tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                    regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);

                                    //素材一覧(共有OA期間)ログ
                                    Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                                    tbj45Vo.setSOZAIYM(MaxSozaiYm);
                                    tbj45Vo.setCMCD(tbj18Vo.getCMCD());
                                    tbj45Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                                    tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                                    tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                    tbj45Vo.setRECNO(newNoVoList.get(0).getRECNO());
                                    regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                                }

                                //素材一覧(共通OA期間)更新：RecNoがNULLのレコードのみが更新対象
                                if(!flg){
                                    List<Tbj43SozaiKanriListCmnOAVO> RecNoIsNullVoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NULL);
                                    for(int i =0; i < RecNoIsNullVoList.size(); i++){
                                        //素材年月の最大値取得
                                        List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm = getMaxSozaiYm(tbj20Vo.getDCARCD(), RecNoIsNullVoList.get(i).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                                        if(maxSozaiYm.get(0).getSOZAIYM() != null){
                                            tbj43Cond.setSozaiym(maxSozaiYm.get(0).getSOZAIYM());
                                        }else{
                                            tbj43Cond.setSozaiym(RecNoIsNullVoList.get(i).getSOZAIYM());
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
                            /** 2016/03/22 HDX対応 HLC K.Soga ADD End */
                        }
                    }
                }
            }
        }

        //登録
        if (vo.getTbj18SozaiKanriDataVOListReg() != null) {
            Tbj18SozaiKanriDataDAO sozaiKanriDao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();
            for (Tbj18SozaiKanriDataVO tbj18SozaiKanriDataVO : vo.getTbj18SozaiKanriDataVOListReg()) {

                //採番テーブルの取得
                Tbj15CmCodeDAO cmCdDao = Tbj15CmCodeDAOFactory.createTbj15CmCodeDAO();
                Tbj15CmCodeCondition cmCodeCon = new Tbj15CmCodeCondition();
                cmCodeCon.setNokbn(tbj18SozaiKanriDataVO.getNOKBN());
                Tbj15CmCodeVO cmCdVo = cmCdDao.selectVO(cmCodeCon).get(0);

                //発行済み番号のカウントアップ
                int existNo = cmCdVo.getEXISTNO().intValue() + 1;
                if (existNo > 9999)
                    throw new HAMException("自動採番桁あふれ", "BJ-E0008");

                //発行済み番号のカウントアップを行った段階で更新
                cmCdVo.setEXISTNO(new BigDecimal(existNo));
                cmCdVo.setUPDDATE(new Date());
                cmCdVo.setUPDAPL(tbj18SozaiKanriDataVO.getUPDAPL());
                cmCdVo.setUPDID(tbj18SozaiKanriDataVO.getUPDID());
                cmCdVo.setUPDNM(tbj18SozaiKanriDataVO.getUPDNM());
                cmCdDao.updateVO(cmCdVo);

                String newCmCd = "0244=" + cmCdVo.getCNTKBN() + existNo;

                //登録処理
                //既にセットされている仮番号をキーとして採番した番号を保持
                cmCdMap.put(tbj18SozaiKanriDataVO.getCMCD(), newCmCd);
                tbj18SozaiKanriDataVO.setCMCD(newCmCd);
                sozaiKanriDao.insertVO(tbj18SozaiKanriDataVO);

                Tbj25LogSozaiKanriDataVO sozaiKanriLogVo = new Tbj25LogSozaiKanriDataVO();
                sozaiKanriLogVo.setNOKBN(tbj18SozaiKanriDataVO.getNOKBN());
                sozaiKanriLogVo.setCMCD(tbj18SozaiKanriDataVO.getCMCD());
                sozaiKanriLogVo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGSTER);
                materialDao.insertMaterialRegisterLog(sozaiKanriLogVo);
            }
        }

        //コンテンツテーブルの登録
        if (vo.getTbj17ContentVo() != null) {
            for (Tbj17ContentVO contVo : vo.getTbj17ContentVo()) {
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

        /** 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD Start */
        // 仮素材情報登録
        //仮10桁CMコードと採番した仮10桁CMコード紐付け用Map
        Map<String, String> tempCmCdMap = new HashMap<String, String>();

        Tbj36TempSozaiKanriDataDAO tbj36dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();
        Tbj41LogTempSozaiKanriDataDAO tbj41dao = Tbj41LogTempSozaiKanriDataDAOFactory.createTbj41LogTempSozaiKanriDataDAO();

        //仮素材削除
        if (vo.getTbj36DelVoList() != null) {
            for (Tbj36TempSozaiKanriDataVO tbj36Vo : vo.getTbj36DelVoList()) {

                //仮素材登録変更ログ削除
                Tbj41LogTempSozaiKanriDataVO tbj41Vo = new Tbj41LogTempSozaiKanriDataVO();
                tbj41Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                /** 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD Start */
                tbj41Vo.setNOKBN(tbj36Vo.getNOKBN());
                Tbj41LogTempSozaiKanriDataCondition tbj41cond = new Tbj41LogTempSozaiKanriDataCondition();
                tbj41cond.setTempcmcd(tbj41Vo.getTEMPCMCD());
                tbj41cond.setNokbn(tbj41Vo.getNOKBN());
                List<Tbj41LogTempSozaiKanriDataVO> tbj41VoList = tbj41dao.selectVO(tbj41cond);
                if (tbj41VoList != null) {
                    for(int i = 0; i < tbj41VoList.size(); i++){
                        tbj41Vo.setHISTORYNO(tbj41VoList.get(i).getHISTORYNO());
                        tbj41dao.deleteVO(tbj41Vo);
                    }
                }
                /** 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD End */

                //仮素材契約紐付け削除
                Tbj40TempSozaiContentVO tbj40Vo = new Tbj40TempSozaiContentVO();
                tbj40Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj40dao.deleteByVo(tbj40Vo);

                //削除処理
                tbj36dao.deleteVO(tbj36Vo);

                //素材一覧物理削除
                MaterialRegisterCondition cond = new MaterialRegisterCondition();
                cond.setTempCmCd(tbj36Vo.getTEMPCMCD());
                List<Tbj20SozaiKanriListVO> tbj20VoList = materialDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_TEMP);

                //取得できない場合、処理継続
                if (tbj20VoList == null || tbj20VoList.size() == 0) {
                    continue;
                } else {
                    for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                        //素材一覧削除
                        tbj20Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                        materialDao.deleteMaterialListAll(tbj20Vo);

                        //素材一覧変更ログ追加
                        Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                        tbj26Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                        materialDao.deleteMaterialListLog(tbj26Vo);

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

                    /** 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD Start */
                    //車種変換マスタ更新用VOリストに追加
                    for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                        tbj20CarConvertVoList.add(tbj20Vo);
                    }
                    /** 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD End */
                }
            }
        }

        //仮素材更新
        if (vo.getTbj36UpdVoList() != null) {
            for (Tbj36TempSozaiKanriDataVO tbj36Vo : vo.getTbj36UpdVoList()) {

                //ステータス
                if (tbj36Vo.getSTATUS() != null && tbj36Vo.getSTATUS().trim().length() == 0) {
                    tbj36Vo.setSTATUS(" ");
                }

                //仮素材テーブル更新
                tbj36Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                //10桁CMコードは変更しないため、null指定
                tbj36Vo.setCMCD(null);
                tbj36dao.updateVO(tbj36Vo);

                //仮素材ログ登録
                Tbj41LogTempSozaiKanriDataVO tbj41Vo = new Tbj41LogTempSozaiKanriDataVO();
                tbj41Vo.setNOKBN(tbj36Vo.getNOKBN());
                tbj41Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj41Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                materialDao.insertTempMaterialRegisterLog(tbj41Vo);

                //素材一覧更新
                MaterialRegisterCondition cond = new MaterialRegisterCondition();
                cond.setTempCmCd(tbj36Vo.getTEMPCMCD());
                List<Tbj20SozaiKanriListVO> tbj20VoList = materialDao.findMaterialAdminListByCondition(cond, HAMConstants.MATERIAL_KBN_TEMP);

                /** 2016/03/31 HDX対応 HLC K.Soga ADD Start */
                //素材一覧(共通OA期間)更新用フラグ：RecNoがNULLのレコードのみが更新対象
                Boolean flg = false;
                /** 2016/03/31 HDX対応 HLC K.Soga ADD End */

                //車種の変更チェック
                if (tbj20VoList.size() <= 0) {
                    //処理継続
                    continue;
                } else {
                    for (Tbj20SozaiKanriListVO tbj20Vo : tbj20VoList) {
                        //タイトル
                        tbj20Vo.setTITLE(tbj36Vo.getTITLE());
                        //秒数
                        tbj20Vo.setSECOND(tbj36Vo.getSECOND());
                        //使用期限期間
                        tbj20Vo.setLIMIT(tbj36Vo.getMLIMIT());
                        //車種担当
                        tbj20Vo.setSYATAN(tbj36Vo.getSYATAN());
                        //データ更新者
                        tbj20Vo.setUPDNM(tbj36Vo.getUPDNM());
                        //更新プログラム
                        tbj20Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                        //更新担当者ID
                        tbj20Vo.setUPDID(tbj36Vo.getUPDID());

                        //車種
                        //車種が変更されていない場合
                        if (tbj36Vo.getDCARCD().equals(tbj20Vo.getDCARCD())) {
                            /** 2016/03/31 HDX対応 HLC K.Soga DEL Start */
                            //年月→変更しないため、null指定
                            //tbj20Vo.setSOZAIYM(null);
                            /** 2016/03/31 HDX対応 HLC K.Soga DEL End */
                            //作成番号→変更しないため、null指定
                            tbj20Vo.setRECNO(null);
                            //車種コード→変更しないため、null指定
                            tbj20Vo.setDCARCD(null);
                        //車種が変更されている場合
                        } else {
                            //車種コード
                            tbj20Vo.setDCARCD(tbj36Vo.getDCARCD());

                            /** 2016/12/01 JASRAC対応 HLC K.Soga ADD Start */
                            //車種変換マスタ更新用VOリストに追加
                            tbj20CarConvertVoList.add(tbj20Vo);
                            /** 2016/12/01 JASRAC対応 HLC K.Soga ADD End */
                        }

                        //素材一覧更新
                        materialDao.updateMaterialList(tbj20Vo, HAMConstants.MATERIAL_KBN_TEMP);

                        /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
                        //素材一覧のNEWNO(RECNO)取得
                        tbj20Vo.setCMCD(null);
                        tbj20Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                        List<Tbj20SozaiKanriListVO> newNoVoList = getNewNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);
                        /** 2016/03/22 HDX対応 HLC K.Soga ADD End */

                        //素材一覧ログ作成
                        Tbj26LogSozaiKanriListVO tbj26Vo = new Tbj26LogSozaiKanriListVO();
                        tbj26Vo.setDCARCD(tbj20Vo.getDCARCD());
                        tbj26Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
                        tbj26Vo.setRECKBN(tbj20Vo.getRECKBN());
                        /** 2016/03/10 HDX対応 HLC K.Soga MOD Start */
                        //tbj26Vo.setRECNO(tbj20Vo.getRECNO());
                        if(newNoVoList.size() > 0){
                            tbj26Vo.setRECNO(newNoVoList.get(0).getRECNO());
                        }
                        tbj26Vo.setTEMPCMCD(tbj20Vo.getTEMPCMCD());
                        /** 2016/03/10 HDX対応 HLC K.Soga MOD End */
                        tbj26Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                        materialDao.insertMaterialListLog(tbj26Vo);

                        /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
                        //素材一覧ログのHISTORYNO取得
                        List<Tbj26LogSozaiKanriListVO> tbj26VoList = getMaxHistoryNo(tbj20Vo.getSOZAIYM(), tbj20Vo.getCMCD(), tbj20Vo.getTEMPCMCD(), HAMConstants.RECKBN_SYSTEM);

                        //車種が変更されていない場合
                        if(tbj20Vo.getDCARCD() == null){
                            if(tbj26VoList.size() > 0){
                                //素材一覧(共通)
                                Tbj42SozaiKanriListCmnCondition tbj42Cond = new Tbj42SozaiKanriListCmnCondition();
                                tbj42Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                                tbj42Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                                List<Tbj42SozaiKanriListCmnVO> tbj42VoList = tbj42Dao.selectVO(tbj42Cond);
                                for(int i = 0; i < tbj42VoList.size(); i++){
                                    //素材一覧ログ(共通)
                                    Tbj44LogSozaiKanriListCmnVO tbj44Vo = new Tbj44LogSozaiKanriListCmnVO();
                                    tbj44Vo.setSOZAIYM(tbj42VoList.get(i).getSOZAIYM());
                                    tbj44Vo.setTEMPCMCD(tbj42VoList.get(i).getTEMPCMCD());
                                    tbj44Vo.setRECKBN(HAMConstants.RECKBN_SYSTEM);
                                    tbj44Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                                    tbj44Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                    regLogMaterialListCmnDao.insertMaterialListCmnLog(tbj44Vo);
                                }
                                Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
                                tbj43Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                                tbj43Cond.setSozaiym(tbj20Vo.getSOZAIYM());
                                List<Tbj43SozaiKanriListCmnOAVO> tbj43VoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NOT_NULL);
                                for(int i = 0; i < tbj43VoList.size(); i++){
                                    //素材一覧(共有OA期間)ログ
                                    Tbj45LogSozaiKanriListCmnOAVO tbj45Vo = new Tbj45LogSozaiKanriListCmnOAVO();
                                    tbj45Vo.setDCARCD(tbj43VoList.get(i).getDCARCD());
                                    tbj45Vo.setSOZAIYM(tbj43VoList.get(i).getSOZAIYM());
                                    tbj45Vo.setRECKBN(tbj43VoList.get(i).getRECKBN());
                                    tbj45Vo.setRECNO(tbj43VoList.get(i).getRECNO());
                                    tbj45Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_UPDATE);
                                    tbj45Vo.setHISTORYNO(tbj26VoList.get(0).getHISTORYNO());
                                    /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD Start */
                                    tbj45Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                                    /** 2016/06/14 HDX不具合対応 HLC K.Soga ADD End */
                                    regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);
                                }
                            }
                        //車種が変更されている場合
                        }else{
                            if(newNoVoList.size() > 0 && tbj26VoList.size() > 0){
                                //素材年月の最大値取得
                                List<Tbj43SozaiKanriListCmnOAVO> prevmaxSozaiym = getMaxSozaiYm(tbj36Vo.getDCARCD(), tbj20Vo.getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                                Date MaxSozaiYm = tbj20Vo.getSOZAIYM();
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
                                Tbj43SozaiKanriListCmnOACondition tbj43Cond = new Tbj43SozaiKanriListCmnOACondition();
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
                                tbj45Vo.setRECNO(newNoVoList.get(0).getRECNO());
                                regLogMaterialListCmnOADao.insertMaterialListCmnOALog(tbj45Vo);

                                //素材一覧(共通OA期間)更新：RecNoがNULLのレコードのみが更新対象
                                if(!flg){
                                    tbj43Cond.setTempcmcd(tbj20Vo.getTEMPCMCD());
                                    List<Tbj43SozaiKanriListCmnOAVO> RecNoIsNullVoList = tbj43Dao.findMaterialListCmnOA(tbj43Cond, HAMConstants.RECNO_IS_NULL);
                                    for(int i =0; i < RecNoIsNullVoList.size(); i++){
                                        //素材年月の最大値取得
                                        List<Tbj43SozaiKanriListCmnOAVO> maxSozaiYm = getMaxSozaiYm(tbj20Vo.getDCARCD(), RecNoIsNullVoList.get(i).getSOZAIYM(), HAMConstants.RECKBN_SYSTEM);
                                        if(maxSozaiYm.get(0).getSOZAIYM() != null){
                                            tbj43Cond.setSozaiym(maxSozaiYm.get(0).getSOZAIYM());
                                        }else{
                                            tbj43Cond.setSozaiym(RecNoIsNullVoList.get(i).getSOZAIYM());
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
        }

        //登録
        if (vo.getTbj36InsVoList() != null) {

            Tbj15CmCodeDAO tbj15dao = Tbj15CmCodeDAOFactory.createTbj15CmCodeDAO();
            Tbj15CmCodeCondition tbj15cond = new Tbj15CmCodeCondition();

            for (Tbj36TempSozaiKanriDataVO tbj36Vo : vo.getTbj36InsVoList()) {

                BigDecimal maxNo = null;
                String newNo = null;

                //タイム
                if (tbj36Vo.getNOKBN().equals(HAMConstants.NOKBN_TIME)) {
                    tbj15cond.setNokbn(HAMConstants.TEMP_NOKBN_TIME);
                    Tbj15CmCodeVO tbj15Vo = tbj15dao.selectVO(tbj15cond).get(0);
                    maxNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));

                    //自動採番更新
                    tbj15Vo.setEXISTNO(maxNo);
                    tbj15Vo.setUPDNM(tbj36Vo.getUPDNM());
                    tbj15Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                    tbj15Vo.setUPDID(tbj36Vo.getUPDID());
                    tbj15dao.updateVO(tbj15Vo);

                    newNo = HAMConstants.TEMPCMCODE_NOKBN_TIME + String.format("%1$05d", maxNo.intValue());
                }
                //スポット
                else if (tbj36Vo.getNOKBN().equals(HAMConstants.NOKBN_SPOT)) {
                    tbj15cond.setNokbn(HAMConstants.TEMP_NOKBN_SPOT);
                    Tbj15CmCodeVO tbj15Vo = tbj15dao.selectVO(tbj15cond).get(0);
                    maxNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));

                    //自動採番更新
                    tbj15Vo.setEXISTNO(maxNo);
                    tbj15Vo.setUPDNM(tbj36Vo.getUPDNM());
                    tbj15Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                    tbj15Vo.setUPDID(tbj36Vo.getUPDID());
                    tbj15dao.updateVO(tbj15Vo);

                    newNo = HAMConstants.TEMPCMCODE_NOKBN_SPOT + String.format("%1$05d", maxNo.intValue());
                }
                //ラジオ
                else if (tbj36Vo.getNOKBN().equals(HAMConstants.NOKBN_RADIO)) {
                    tbj15cond.setNokbn(HAMConstants.TEMP_NOKBN_RADIO);
                    Tbj15CmCodeVO tbj15Vo = tbj15dao.selectVO(tbj15cond).get(0);
                    maxNo = tbj15Vo.getEXISTNO().add(BigDecimal.valueOf(1));

                    //自動採番更新
                    tbj15Vo.setEXISTNO(maxNo);
                    tbj15Vo.setUPDNM(tbj36Vo.getUPDNM());
                    tbj15Vo.setUPDAPL(tbj36Vo.getUPDAPL());
                    tbj15Vo.setUPDID(tbj36Vo.getUPDID());
                    tbj15dao.updateVO(tbj15Vo);

                    newNo = HAMConstants.TEMPCMCODE_NOKBN_RADIO + String.format("%1$05d", maxNo.intValue());
                }

                //仮素材
                //既にセットされている仮番号をキーとして採番した番号を保持
                tempCmCdMap.put(tbj36Vo.getTEMPCMCD(), newNo);
                tbj36Vo.setTEMPCMCD(String.valueOf(newNo));
                tbj36dao.insertVO(tbj36Vo);

                //仮素材ログ登録
                Tbj41LogTempSozaiKanriDataVO tbj41Vo = new Tbj41LogTempSozaiKanriDataVO();
                tbj41Vo.setNOKBN(tbj36Vo.getNOKBN());
                tbj41Vo.setTEMPCMCD(tbj36Vo.getTEMPCMCD());
                tbj41Vo.setHISTORYKBN(HAMConstants.HISTORYKBN_REGISTER_TEMP);
                materialDao.insertTempMaterialRegisterLog(tbj41Vo);
            }
        }

        //契約仮素材紐付け情報追加
        if (vo.getTbj40VoList() != null) {
            for (Tbj40TempSozaiContentVO tbj40Vo : vo.getTbj40VoList()) {
                if (ctrtNoMap.containsKey(tbj40Vo.getCTRTKBN() + "|" + tbj40Vo.getCTRTNO())) {
                    //仮番号が入っている場合は採番した値に置き換える
                    tbj40Vo.setCTRTNO(ctrtNoMap.get(tbj40Vo.getCTRTKBN() + "|" + tbj40Vo.getCTRTNO()));
                }
                if (tempCmCdMap.containsKey(tbj40Vo.getTEMPCMCD())) {
                    //仮番号が入っている場合は採番した値に置き換える
                    tbj40Vo.setTEMPCMCD(tempCmCdMap.get(tbj40Vo.getTEMPCMCD()));
                }

                tbj40dao.insertVO(tbj40Vo);
            }
        }
        /* 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD End */
        //素材登録テーブル(権利使用期限)の更新
        if (allContractInfoVoList != null) {
            for (Tbj16ContractInfoUpdateVO tbj16ContractInfoUpdateVO : allContractInfoVoList) {
                refreshCtrt(tbj16ContractInfoUpdateVO);
            }
        }

        //車種変換マスタ更新VO
        Mbj38CarConvertVO mbj38Vo = new Mbj38CarConvertVO();

        if (tbj20CarConvertVoList.size() != 0) {

            //車種変換マスタ更新VOリスト全件ループ処理
            for (Tbj20SozaiKanriListVO tbj20Vo : tbj20CarConvertVoList) {

                mbj38Vo = ContractMaterialUtil.getCarConvertUpdateVo(tbj20Vo);
                mbj38Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());

                //車種変換マスタ削除処理
                Mbj38CarConvertDAO mbj38Dao = Mbj38CarConvertDAOFactory.createMbj38CarConvertDAO();
                mbj38Dao.deleteByMonth(mbj38Vo);

                //車種変換マスタ追加処理
                materialDao.insertCarConvert(mbj38Vo);
            }
        }

        return result;
    }

    /**
     * 指定した契約種類、契約コードを使用している素材登録の権利使用期限を更新する
     * @throws HAMException
     */
    private void refreshCtrt(Tbj16ContractInfoUpdateVO vo) throws HAMException {

        //入力チェック
        if (vo == null) {
            return;
        }

        ContractRegisterDao dao = ContractRegisterDaoFactory.createContractRegisterDao();
        List<GetContentMaterialVO> getDataVoList = dao.getContentMaterialCondition(vo);

        Tbj18SozaiKanriDataDAO sozaiDao = Tbj18SozaiKanriDataDAOFactory.createTbj18SozaiKanriDataDAO();
        /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
        Tbj36TempSozaiKanriDataDAO tbj36Dao = Tbj36TempSozaiKanriDataDAOFactory.createTbj36TempSozaiKanriDataDAO();

        boolean tempFlg = false;
        /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

        KlimitUtil klimit = new KlimitUtil();
        String oldCmCd = "";

        for (int i = 0; i <getDataVoList.size(); i++) {
            GetContentMaterialVO getDataVo = getDataVoList.get(i);

            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
            if (!getDataVo.getTEMPFLG().equals(HAMConstants.MATERIAL_KBN_ACTUAL)) {
                tempFlg = true;
            }
            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

            if (!oldCmCd.equals(getDataVo.getCMCD())) {
                klimit.clear();
            }

            //権利使用期限の生成に必要な条件データを追加
            String key = klimit.getKey(getDataVo.getCTRTKBN(), getDataVo.getNAMES(), getDataVo.getMUSIC());
            klimit.addSpan(key, getDataVo.getDATEFROM(), getDataVo.getDATETO());

            if (getDataVoList.size() == i + 1 || !getDataVo.getCMCD().equals(getDataVoList.get(i + 1).getCMCD())) {
                //全体の最終データか素材ごとの最終データの場合は更新処理を実行

                /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
                if (!tempFlg) {
                //本素材
                /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

                    Tbj18SozaiKanriDataVO sozaiVo = new Tbj18SozaiKanriDataVO();
                    sozaiVo.setCMCD(getDataVo.getCMCD());

                    //権利使用期限の生成実行
                    klimit.generateKlimit();
                    if (klimit.termCount() > 0) {
                        if (klimit.minDate() != null
                                && getDataVo.getHOUSOUDATEFROM() != null
                                && klimit.minDate().compareTo(getDataVo.getHOUSOUDATEFROM()) <= 0) {
                            sozaiVo.setKLIMIT(klimit.limit());
                        } else {
                            sozaiVo.setKLIMIT(klimit.resultSpan());
                        }
                    } else {
                        //対象の期間がない場合は空
                        sozaiVo.setKLIMIT("");
                    }

                    sozaiVo.setUPDAPL(vo.getUPDAPL());
                    sozaiVo.setUPDID(vo.getUPDID());
                    sozaiVo.setUPDNM(vo.getUPDNM());
                    sozaiDao.updateVO(sozaiVo);

                /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
                } else {
                    //仮素材

                    Tbj36TempSozaiKanriDataVO tbj36Vo = new Tbj36TempSozaiKanriDataVO();
                    tbj36Vo.setTEMPCMCD(getDataVo.getCMCD());

                    //権利使用期限の生成実行
                    klimit.generateKlimit();
                    if (klimit.termCount() > 0) {
                        if (klimit.minDate() != null
                                && getDataVo.getHOUSOUDATEFROM() != null
                                && klimit.minDate().compareTo(getDataVo.getHOUSOUDATEFROM()) <= 0) {
                            tbj36Vo.setKLIMIT(klimit.limit());
                        } else {
                            tbj36Vo.setKLIMIT(klimit.resultSpan());
                        }
                    } else {
                        //対象の期間がない場合は空
                        tbj36Vo.setKLIMIT("");
                    }

                    tbj36Vo.setUPDAPL(vo.getUPDAPL());
                    tbj36Vo.setUPDID(vo.getUPDID());
                    tbj36Vo.setUPDNM(vo.getUPDNM());
                    tbj36Dao.updateVO(tbj36Vo);
                }
            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */
            }

            oldCmCd = getDataVo.getCMCD();
        }
    }

    /**
     * 画面再表示時契約情報テーブル取得リストを検索します
     *
     * @return GetContractInfoListResult 汎用マスタ検索データ
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public GetContractInfoListResult getContractByCondition(GetContractInfoListCondition cond) throws HAMException {

        //検索結果
        GetContractInfoListResult result = new GetContractInfoListResult();

        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();

        //契約情報テーブルの取得
        Tbj16ContractInfoDAO contractInfoDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
        Tbj16ContractInfoCondition contractInfoCond = new Tbj16ContractInfoCondition();
        contractInfoCond.setDelflg(" ");
        result.setTbj16ContractInfoVOList(contractInfoDao.selectVOForLIST(contractInfoCond));

        //使用素材表示用(タレント・ナレーター)データの取得
        result.setFindUseMaterialTalentVOList(contractRegisterDao.findUseMaterialTalentListByCondition());

        //使用素材表示用(楽曲)データの取得
        result.setFindUseMaterialMusicVOList(contractRegisterDao.findUseMaterialMusicListByCondition());

        return result;
    }

    /**
     * 更新履歴画面の表示データを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindLogContractInfoResult findLogContractInfo(FindLogContractInfoCondition cond) throws HAMException {

        //検索結果
        FindLogContractInfoResult result = new FindLogContractInfoResult();

        //履歴表示用データの取得
        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();
        result.setFindLogContractInfoVoList(contractRegisterDao.findLogContractInfo(cond));

        return result;
    }

    /**
     * JASRACテーブル
     *
     * @return ContractRegisterResult 汎用マスタ検索データ
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public ContractDeleteResult countJasracByCondition(ContractDeleteCondition cond) throws HAMException {

        //検索結果
        ContractDeleteResult result = new ContractDeleteResult();

        //JASRACテーブルのカウントの取得
        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();
        result.setContractDeleteJVOList(contractRegisterDao.countJasracListByCondition(cond));

        return result;
    }

    /**
     * 素材検索に表示するデータを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public MaterialSearchResult getIniDataForMaterialSearch(MaterialSearchCondition cond) throws HAMException {

        //検索結果
        MaterialSearchResult result = new MaterialSearchResult();

        //画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO displayControlDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition displayControlCond = new Mbj37DisplayControlCondition();
        displayControlCond.setFormid(cond.getFormid());
        result.setMbj37DisplayControlVoList(displayControlDao.selectVO(displayControlCond));

        //素材登録データ取得
        ContractRegisterDao contractRegisterDao = ContractRegisterDaoFactory.createContractRegisterDao();
        result.setSozaiKanriDataList(contractRegisterDao.findSozaiKanriData(cond));

        return result;
    }

    /**
     * 契約情報登録の登録時の排他チェック処理を行う
     * @param vo 登録VO
     * @return 排他チェック結果
     * @throws HAMException
     */
    private boolean checkExclusionForUpdateContractInfo(UpdateContractInfoVO vo) throws HAMException {

        //排他チェック対象のデータを一つのリストにまとめる
        List<Tbj16ContractInfoUpdateVO> lst = new ArrayList<Tbj16ContractInfoUpdateVO>();
        if (vo.getTbj16ContractInfoUpdateVOListUpd() != null)
            lst.addAll(vo.getTbj16ContractInfoUpdateVOListUpd());

        if (vo.getTbj16ContractInfoUpdateVOListDel() != null)
            lst.addAll(vo.getTbj16ContractInfoUpdateVOListDel());

        if (lst == null || lst.size() == 0) {
            return true;
        }

        //排他チェック対象のデータの最新の状態を取得する
        Tbj16ContractInfoDAO dao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
        List<Tbj16ContractInfoVO> condList = new ArrayList<Tbj16ContractInfoVO>();
        if (lst != null) {
            for (Tbj16ContractInfoUpdateVO updVo : lst) {
                Tbj16ContractInfoVO condVo = new Tbj16ContractInfoVO();
                condVo.setCTRTKBN(updVo.getCTRTKBNOLD());
                condVo.setCTRTNO(updVo.getCTRTNO());
                condList.add(condVo);
            }
        }
        List<Tbj16ContractInfoVO> lockDatas = dao.selectByPkWithLock(condList);

        //取得した最新データと検索時点の情報を比較して検索時より後に更新されていないかチェック
        //取得したデータをMapへ格納しなおす
        Map<String, Date> tempVoMap = new HashMap<String, Date>();
        for (Tbj16ContractInfoVO lockData : lockDatas) {
            tempVoMap.put(getKeyForCrContractInfo(lockData), lockData.getUPDDATE());
        }
        for (Tbj16ContractInfoVO tbj16ContractInfo : condList) {
            //取得したデータの中に更新しようとしているデータがなければ排他エラー
            if (!tempVoMap.containsKey(getKeyForCrContractInfo(tbj16ContractInfo))) {
                return false;
            }
            //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
            if (vo.getMaxDateTimeForContractInfo().before(tempVoMap.get(getKeyForCrContractInfo(tbj16ContractInfo)))) {
                return false;
            }
        }

        return true;
    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(契約情報)
     * @param vo 登録VO
     * @return 一意判別キー文字列
     */
    private String getKeyForCrContractInfo(Tbj16ContractInfoVO vo) {
        return vo.getCTRTKBN() + "|" + vo.getCTRTNO();
    }

    /** 2016/03/22 HDX対応 HLC K.Soga ADD Start */
    /**
     * 素材一覧ログのHISTORYNO取得
     * @return 素材一覧ログリスト
     */
    private List<Tbj26LogSozaiKanriListVO> getMaxHistoryNo(Date sozaiym, String cmCd, String tempCmCd, String recKbn) throws HAMException {
        Tbj26LogSozaiKanriListDAO tbj26Dao = Tbj26LogSozaiKanriListDAOFactory.createTbj26LogSozaiKanriListDAO();
        Tbj26LogSozaiKanriListCondition tbj26Cond = new Tbj26LogSozaiKanriListCondition();
        tbj26Cond.setReckbn(recKbn);
        tbj26Cond.setSozaiym(sozaiym);
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
}
