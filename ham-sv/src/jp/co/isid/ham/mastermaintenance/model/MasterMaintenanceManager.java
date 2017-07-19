package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.*;
import jp.co.isid.ham.integ.tbl.Mbj01SysSts;
import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj04Keiretsu;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj07HcUser;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj20CarCategory;
import jp.co.isid.ham.integ.tbl.Mbj22CategoryContent;
import jp.co.isid.ham.integ.tbl.Mbj23CarTanto;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj27MediaProduct;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Mbj31Information;
import jp.co.isid.ham.integ.tbl.Mbj32Department;
import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.ham.integ.tbl.Mbj35MediaPattern;
import jp.co.isid.ham.integ.tbl.Mbj36MediaPatternItem;
import jp.co.isid.ham.integ.tbl.Mbj40AlertMailAddress;
import jp.co.isid.ham.integ.tbl.Mbj41AlertDispControl;
import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj43SecurityItem;
import jp.co.isid.ham.integ.tbl.Mbj44SecurityBase;
import jp.co.isid.ham.integ.tbl.Mbj47Newspaper;
import jp.co.isid.ham.integ.tbl.Mbj48HmUser;
import jp.co.isid.ham.integ.tbl.Mbj52SzTntUser;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * マスタメンテナンスManager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S,Fujimoto)<BR>
 * ・HDX対応(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author 森
 */
public class MasterMaintenanceManager
{
    /** シングルトンインスタンス */
    private static MasterMaintenanceManager _manager = new MasterMaintenanceManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private MasterMaintenanceManager()
    {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static MasterMaintenanceManager getInstance() {
        return _manager;
    }

    /**
     * 過去ロック登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceLock(RegistMbj01SysStsVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj01SysSts.TBNAME,Mbj01SysSts.PREFIX);
        Mbj01SysStsDAO dao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 過去ロック検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj01SysStsVO getMasterMaintenanceLock(Mbj01SysStsCondition condition) throws HAMException {

        FindMbj01SysStsVO vo = new FindMbj01SysStsVO();

        if (condition != null) {
            Mbj01SysStsDAO dao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 担当者登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceUser(RegistMbj02UserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj02User.TBNAME,Mbj02User.PREFIX);
        Mbj02UserDAO dao = Mbj02UserDAOFactory.createMbj02UserDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 担当者検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj02UserVO getMasterMaintenanceUser(Mbj02UserCondition condition) throws HAMException {

        FindMbj02UserVO vo = new FindMbj02UserVO();

        if (condition != null) {
            Mbj02UserDAO dao = Mbj02UserDAOFactory.createMbj02UserDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 車種権限登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarAuthority(RegistMbj11CarSecVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj11CarSec.TBNAME,Mbj11CarSec.PREFIX);
        Mbj11CarSecDAO dao = Mbj11CarSecDAOFactory.createMbj11CarSecDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 車種権限検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj11CarSecVO getMasterMaintenanceCarAuthority(Mbj11CarSecCondition condition) throws HAMException {

        FindMbj11CarSecVO vo = new FindMbj11CarSecVO();

        if (condition != null) {
            Mbj11CarSecDAO dao = Mbj11CarSecDAOFactory.createMbj11CarSecDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 媒体権限登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceMediaAuthority(RegistMbj10MediaSecVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj10MediaSec.TBNAME,Mbj10MediaSec.PREFIX);
        Mbj10MediaSecDAO dao = Mbj10MediaSecDAOFactory.createMbj10MediaSecDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 媒体権限検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj10MediaSecVO getMasterMaintenanceMediaAuthority(Mbj10MediaSecCondition condition) throws HAMException
    {
        FindMbj10MediaSecVO vo = new FindMbj10MediaSecVO();

        if (condition != null) {
            Mbj10MediaSecDAO dao = Mbj10MediaSecDAOFactory.createMbj10MediaSecDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 系列登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceSeries(RegistMbj04KeiretsuVO vo) throws HAMException
    {
        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj04Keiretsu.TBNAME,Mbj04Keiretsu.PREFIX);
        checkRegistMasterMaintenanceSeries(vo);
        Mbj04KeiretsuDAO dao = Mbj04KeiretsuDAOFactory.createMbj04KeiretsuDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 系列検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj04KeiretsuVO getMasterMaintenanceSeries(Mbj04KeiretsuCondition condition) throws HAMException {

        FindMbj04KeiretsuVO vo = new FindMbj04KeiretsuVO();

        if (condition != null) {
            Mbj04KeiretsuDAO dao = Mbj04KeiretsuDAOFactory.createMbj04KeiretsuDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 車種登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCar(RegistMbj05CarVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj05Car.TBNAME,Mbj05Car.PREFIX);
        Mbj05CarDAO dao = Mbj05CarDAOFactory.createMbj05CarDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 車種検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj05CarVO getMasterMaintenanceCar(Mbj05CarCondition condition) throws HAMException {

        FindMbj05CarVO vo = new FindMbj05CarVO();

        if (condition != null) {
            Mbj05CarDAO dao = Mbj05CarDAOFactory.createMbj05CarDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 車種出力設定登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarOutControl(RegistMbj13CarOutCtrlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj13CarOutCtrl.TBNAME,Mbj13CarOutCtrl.PREFIX);
        Mbj13CarOutCtrlDAO dao = Mbj13CarOutCtrlDAOFactory.createMbj13CarOutCtrlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 車種出力設定検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj13CarOutCtrlVO getMasterMaintenanceCarOutControl(Mbj13CarOutCtrlCondition condition) throws HAMException {

        FindMbj13CarOutCtrlVO vo = new FindMbj13CarOutCtrlVO();

        if (condition != null) {
            Mbj13CarOutCtrlDAO dao = Mbj13CarOutCtrlDAOFactory.createMbj13CarOutCtrlDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 媒体登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceMedia(RegistMbj03MediaVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj03Media.TBNAME,Mbj03Media.PREFIX);
        Mbj03MediaDAO dao = Mbj03MediaDAOFactory.createMbj03MediaDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 媒体検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj03MediaVO getMasterMaintenanceMedia(Mbj03MediaCondition condition) throws HAMException {

        FindMbj03MediaVO vo = new FindMbj03MediaVO();

        if (condition != null) {
            Mbj03MediaDAO dao = Mbj03MediaDAOFactory.createMbj03MediaDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;

    }

    /**
     * 媒体出力設定登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceMediaOutControl(RegistMbj14MediaOutCtrlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj14MediaOutCtrl.TBNAME,Mbj14MediaOutCtrl.PREFIX);
        Mbj14MediaOutCtrlDAO dao = Mbj14MediaOutCtrlDAOFactory.createMbj14MediaOutCtrlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 媒体出力設定検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj14MediaOutCtrlVO getMasterMaintenanceMediaOutControl(Mbj14MediaOutCtrlCondition condition) throws HAMException {

        FindMbj14MediaOutCtrlVO vo = new FindMbj14MediaOutCtrlVO();

        if (condition != null) {
            Mbj14MediaOutCtrlDAO dao = Mbj14MediaOutCtrlDAOFactory.createMbj14MediaOutCtrlDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 費用企画No登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCostPlan(RegistMbj09HiyouVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj09Hiyou.TBNAME,Mbj09Hiyou.PREFIX);
        Mbj09HiyouDAO dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 費用企画No検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj09HiyouVO getMasterMaintenanceCostPlan(Mbj09HiyouCondition condition) throws HAMException {

        FindMbj09HiyouVO vo = new FindMbj09HiyouVO();

        if (condition != null) {
            Mbj09HiyouDAO dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 車種カテゴリ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarCategory(RegistMbj20CarCategoryVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj20CarCategory.TBNAME,Mbj20CarCategory.PREFIX);
        Mbj20CarCategoryDAO dao = Mbj20CarCategoryDAOFactory.createMbj20CarCategoryDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 車種カテゴリ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj20CarCategoryVO getMasterMaintenanceCarCategory(Mbj20CarCategoryCondition condition) throws HAMException {

        FindMbj20CarCategoryVO vo = new FindMbj20CarCategoryVO();

        if (condition != null) {
            Mbj20CarCategoryDAO dao = Mbj20CarCategoryDAOFactory.createMbj20CarCategoryDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 車種カテゴリ紐付登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarCategoryContent(RegistMbj22CategoryContentVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj22CategoryContent.TBNAME,Mbj22CategoryContent.PREFIX);

        if (vo.getInsertList() != null) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkRegistMasterMaintenanceCarCategoryContent(vo.getInsertList());
        }

        Mbj22CategoryContentDAO dao = Mbj22CategoryContentDAOFactory.createMbj22CategoryContentDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 車種カテゴリ紐付検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj22CategoryContentVO getMasterMaintenanceCarCategoryContent(Mbj22CategoryContentCondition condition) throws HAMException {

        FindMbj22CategoryContentVO vo = new FindMbj22CategoryContentVO();

        if (condition != null) {
            Mbj22CategoryContentDAO dao = Mbj22CategoryContentDAOFactory.createMbj22CategoryContentDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 車種担当登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarUser(RegistMbj23CarTantoVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj23CarTanto.TBNAME,Mbj23CarTanto.PREFIX);
        Mbj23CarTantoDAO dao = Mbj23CarTantoDAOFactory.createMbj23CarTantoDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 車種担当検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj23CarTantoVO getMasterMaintenanceCarUser(Mbj23CarTantoCondition condition) throws HAMException {

        FindMbj23CarTantoVO vo = new FindMbj23CarTantoVO();

        if (condition != null) {
            Mbj23CarTantoDAO dao = Mbj23CarTantoDAOFactory.createMbj23CarTantoDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 請求先グループ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceDemandGroup(RegistMbj26BillGroupVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj26BillGroup.TBNAME,Mbj26BillGroup.PREFIX);
        checkRegistMasterMaintenanceDemandGroup(vo);
        Mbj26BillGroupDAO dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 請求先グループ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj26BillGroupVO getMasterMaintenanceDemandGroup(Mbj26BillGroupCondition condition) throws HAMException {

        FindMbj26BillGroupVO vo = new FindMbj26BillGroupVO();

        if (condition != null) {
            Mbj26BillGroupDAO dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * HC部門登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceHCSection(RegistMbj06HcBumonVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj06HcBumon.TBNAME,Mbj06HcBumon.PREFIX);
        checkRegistMasterMaintenanceHCSection(vo);
        Mbj06HcBumonDAO dao = Mbj06HcBumonDAOFactory.createMbj06HcBumonDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC部門検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj06HcBumonVO getMasterMaintenanceHCSection(Mbj06HcBumonCondition condition) throws HAMException {

        FindMbj06HcBumonVO vo = new FindMbj06HcBumonVO();

        if (condition != null) {
            Mbj06HcBumonDAO dao = Mbj06HcBumonDAOFactory.createMbj06HcBumonDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * HC担当者登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceHCUser(RegistMbj07HcUserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj07HcUser.TBNAME,Mbj07HcUser.PREFIX);
        Mbj07HcUserDAO dao = Mbj07HcUserDAOFactory.createMbj07HcUserDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC担当者検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj07HcUserVO getMasterMaintenanceHCUser(Mbj07HcUserCondition condition) throws HAMException {

        FindMbj07HcUserVO vo = new FindMbj07HcUserVO();

        if (condition != null) {
            Mbj07HcUserDAO dao = Mbj07HcUserDAOFactory.createMbj07HcUserDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * HC商品登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceHCProduct(RegistMbj08HcProductVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj08HcProduct.TBNAME,Mbj08HcProduct.PREFIX);
        Mbj08HcProductDAO dao = Mbj08HcProductDAOFactory.createMbj08HcProductDAO();

        // レコード全削除
        dao.allDelete();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC商品検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj08HcProductVO getMasterMaintenanceHCProduct(Mbj08HcProductCondition condition) throws HAMException {

        FindMbj08HcProductVO vo = new FindMbj08HcProductVO();

        if (condition != null) {
            Mbj08HcProductDAO dao = Mbj08HcProductDAOFactory.createMbj08HcProductDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 媒体・商品紐付登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceMediaProduct(RegistMbj27MediaProductVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj27MediaProduct.TBNAME,Mbj27MediaProduct.PREFIX);
        Mbj27MediaProductDAO dao = Mbj27MediaProductDAOFactory.createMbj27MediaProductDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 媒体・商品紐付検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj27MediaProductVO getMasterMaintenanceMediaProduct(Mbj27MediaProductCondition condition) throws HAMException {

        FindMbj27MediaProductVO vo = new FindMbj27MediaProductVO();

        if (condition != null) {
            Mbj27MediaProductDAO dao = Mbj27MediaProductDAOFactory.createMbj27MediaProductDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 設定局登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceEstablishmentOffice(RegistMbj29SetteiKykVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj29SetteiKyk.TBNAME,Mbj29SetteiKyk.PREFIX);
        checkRegistMasterMaintenanceEstablishmentOffice(vo);
        Mbj29SetteiKykDAO dao = Mbj29SetteiKykDAOFactory.createMbj29SetteiKykDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 設定局検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj29SetteiKykVO getMasterMaintenanceEstablishmentOffice(Mbj29SetteiKykCondition condition) throws HAMException {

        FindMbj29SetteiKykVO vo = new FindMbj29SetteiKykVO();

        if (condition != null) {
            Mbj29SetteiKykDAO dao = Mbj29SetteiKykDAOFactory.createMbj29SetteiKykDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 入力担当登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceInputUser(RegistMbj30InputTntVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj30InputTnt.TBNAME,Mbj30InputTnt.PREFIX);
        checkRegistMasterMaintenanceInputUser(vo);
        Mbj30InputTntDAO dao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 入力担当登録データVO削除（電通車種コード指定）
     *
     * @param vo データVO
     */
    public void deleteMasterMaintenanceInputUserDCARCD(RegistMbj30InputTntVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj30InputTnt.TBNAME,Mbj30InputTnt.PREFIX);
        Mbj30InputTntDAO dao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            Mbj30InputTntCondition mbj30condition = new Mbj30InputTntCondition();
            mbj30condition.setDcarcd(vo.getDeleteList().get(i).getDCARCD());
            List<Mbj30InputTntVO> checkListMbj30VO = dao.selectVO(mbj30condition);

            for (int j = 0 ; (checkListMbj30VO != null) && (j < checkListMbj30VO.size()) ; j++) {
                List<Mbj30InputTntVO> workListMbj30VO = new ArrayList<Mbj30InputTntVO>();
                workListMbj30VO.add(checkListMbj30VO.get(j));

                try {
                    checkDao.checkDeleteMasterMaintenanceInputUser(workListMbj30VO);
                } catch(HAMException e) {
                    if (!e.getErrorID().equals("BJ-W0047")) {
                        throw e;
                    }

                    continue;
                }

                dao.deleteVO(checkListMbj30VO.get(j));
            }
        }
    }

    /**
     * 入力担当検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj30InputTntVO getMasterMaintenanceInputUser(Mbj30InputTntCondition condition) throws HAMException {

        FindMbj30InputTntVO vo = new FindMbj30InputTntVO();

        if (condition != null) {
            Mbj30InputTntDAO dao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 機能制御登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceFunctionControl(RegistMbj33FunctionControlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.PREFIX);
        Mbj33FunctionControlDAO dao = Mbj33FunctionControlDAOFactory.createMbj33FunctionControlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 機能制御検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj33FunctionControlVO getMasterMaintenanceFunctionControl(Mbj33FunctionControlCondition condition) throws HAMException {

        FindMbj33FunctionControlVO vo = new FindMbj33FunctionControlVO();

        if (condition != null) {
            Mbj33FunctionControlDAO dao = Mbj33FunctionControlDAOFactory.createMbj33FunctionControlDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 機能制御項目登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceFunctionControlItem(RegistMbj34FunctionControlItemVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.PREFIX);
        Mbj34FunctionControlItemDAO dao = Mbj34FunctionControlItemDAOFactory.createMbj34FunctionControlItemDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 機能制御項目検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj34FunctionControlItemVO getMasterMaintenanceFunctionControlItem(Mbj34FunctionControlItemCondition condition) throws HAMException {

        FindMbj34FunctionControlItemVO vo = new FindMbj34FunctionControlItemVO();

        if (condition != null) {
            Mbj34FunctionControlItemDAO dao = Mbj34FunctionControlItemDAOFactory.createMbj34FunctionControlItemDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 機能制御ベース登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceFunctionControlBase(RegistMbj39FunctionControlBaseVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.PREFIX);
        Mbj39FunctionControlBaseDAO dao = Mbj39FunctionControlBaseDAOFactory.createMbj39FunctionControlBaseDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 機能制御ベース検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj39FunctionControlBaseVO getMasterMaintenanceFunctionControlBase(Mbj39FunctionControlBaseCondition condition) throws HAMException {

        FindMbj39FunctionControlBaseVO vo = new FindMbj39FunctionControlBaseVO();

        if (condition != null) {
            Mbj39FunctionControlBaseDAO dao = Mbj39FunctionControlBaseDAOFactory.createMbj39FunctionControlBaseDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * インフォメーション登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceInformation(RegistMbj31InformationVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj31Information.TBNAME,Mbj31Information.PREFIX);
        Mbj31InformationDAO dao = Mbj31InformationDAOFactory.createMbj31InformationDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * インフォメーション検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj31InformationVO getMasterMaintenanceInformation(Mbj31InformationCondition condition) throws HAMException {

        FindMbj31InformationVO vo = new FindMbj31InformationVO();

        if (condition != null) {
            Mbj31InformationDAO dao = Mbj31InformationDAOFactory.createMbj31InformationDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 部署登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceDepartment(RegistMbj32DepartmentVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj32Department.TBNAME,Mbj32Department.PREFIX);
        Mbj32DepartmentDAO dao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 部署検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj32DepartmentVO getMasterMaintenanceDepartment(Mbj32DepartmentCondition condition) throws HAMException {

        FindMbj32DepartmentVO vo = new FindMbj32DepartmentVO();

        if (condition != null) {
            Mbj32DepartmentDAO dao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 媒体パターン登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceMediaPattern(RegistMbj35MediaPatternVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj35MediaPattern.TBNAME,Mbj35MediaPattern.PREFIX);
        Mbj35MediaPatternDAO dao = Mbj35MediaPatternDAOFactory.createMbj35MediaPatternDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 媒体パターン検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj35MediaPatternVO getMasterMaintenanceMediaPattern(Mbj35MediaPatternCondition condition) throws HAMException {

        FindMbj35MediaPatternVO vo = new FindMbj35MediaPatternVO();

        if (condition != null) {
            Mbj35MediaPatternDAO dao = Mbj35MediaPatternDAOFactory.createMbj35MediaPatternDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 媒体パターン内容登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceMediaPatternItem(RegistMbj36MediaPatternItemVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj36MediaPatternItem.TBNAME,Mbj36MediaPatternItem.PREFIX);
        Mbj36MediaPatternItemDAO dao = Mbj36MediaPatternItemDAOFactory.createMbj36MediaPatternItemDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 媒体パターン内容検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj36MediaPatternItemVO getMasterMaintenanceMediaPatternItem(Mbj36MediaPatternItemCondition condition) throws HAMException {

        FindMbj36MediaPatternItemVO vo = new FindMbj36MediaPatternItemVO();

        if (condition != null) {
            Mbj36MediaPatternItemDAO dao = Mbj36MediaPatternItemDAOFactory.createMbj36MediaPatternItemDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * コードマスタ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCode(RegistMbj12CodeVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj12Code.TBNAME,Mbj12Code.PREFIX);
        Mbj12CodeDAO dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * コードマスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj12CodeVO getMasterMaintenanceCode(Mbj12CodeCondition condition) throws HAMException {

        FindMbj12CodeVO vo = new FindMbj12CodeVO();

        if (condition != null) {
            Mbj12CodeDAO dcDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * メール配信マスタ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceAlertMailAddress(RegistMbj40AlertMailAddressVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj40AlertMailAddress.TBNAME,Mbj40AlertMailAddress.PREFIX);
        Mbj40AlertMailAddressDAO dao = Mbj40AlertMailAddressDAOFactory.createMbj40AlertMailAddressDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * メール配信マスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj40AlertMailAddressVO getMasterMaintenanceAlertMailAddress(Mbj40AlertMailAddressCondition condition) throws HAMException {

        FindMbj40AlertMailAddressVO vo = new FindMbj40AlertMailAddressVO();

        if (condition != null) {
            Mbj40AlertMailAddressDAO dcDao = Mbj40AlertMailAddressDAOFactory.createMbj40AlertMailAddressDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * アラート表示制御マスタ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceAlertDispControl(RegistMbj41AlertDispControlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj41AlertDispControl.TBNAME,Mbj41AlertDispControl.PREFIX);
        Mbj41AlertDispControlDAO dao = Mbj41AlertDispControlDAOFactory.createMbj41AlertDispControlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVOWhereNoPrimaryKey(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * アラート表示制御マスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj41AlertDispControlVO getMasterMaintenanceAlertDispControl(Mbj41AlertDispControlCondition condition) throws HAMException {

        FindMbj41AlertDispControlVO vo = new FindMbj41AlertDispControlVO();

        if (condition != null) {
            Mbj41AlertDispControlDAO dcDao = Mbj41AlertDispControlDAOFactory.createMbj41AlertDispControlDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * セキュリティ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceSecurity(RegistMbj42SecurityVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj42Security.TBNAME,Mbj42Security.PREFIX);
        Mbj42SecurityDAO dao = Mbj42SecurityDAOFactory.createMbj42SecurityDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * セキュリティ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj42SecurityVO getMasterMaintenanceSecurity(Mbj42SecurityCondition condition) throws HAMException {

        FindMbj42SecurityVO vo = new FindMbj42SecurityVO();

        if (condition != null) {
            Mbj42SecurityDAO dao = Mbj42SecurityDAOFactory.createMbj42SecurityDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * セキュリティ項目マスタ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceSecurityItem(RegistMbj43SecurityItemVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.PREFIX);
        Mbj43SecurityItemDAO dao = Mbj43SecurityItemDAOFactory.createMbj43SecurityItemDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * セキュリティ項目マスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj43SecurityItemVO getMasterMaintenanceSecurityItem(Mbj43SecurityItemCondition condition) throws HAMException {

        FindMbj43SecurityItemVO vo = new FindMbj43SecurityItemVO();

        if (condition != null) {
            Mbj43SecurityItemDAO dcDao = Mbj43SecurityItemDAOFactory.createMbj43SecurityItemDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * セキュリティベースマスタ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceSecurityBase(RegistMbj44SecurityBaseVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj44SecurityBase.TBNAME,Mbj44SecurityBase.PREFIX);
        Mbj44SecurityBaseDAO dao = Mbj44SecurityBaseDAOFactory.createMbj44SecurityBaseDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * セキュリティベースマスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj44SecurityBaseVO getMasterMaintenanceSecurityBase(Mbj44SecurityBaseCondition condition) throws HAMException {

        FindMbj44SecurityBaseVO vo = new FindMbj44SecurityBaseVO();

        if (condition != null) {
            Mbj44SecurityBaseDAO dcDao = Mbj44SecurityBaseDAOFactory.createMbj44SecurityBaseDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 新聞マスタ登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceNewspaper(RegistMbj47NewspaperVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj47Newspaper.TBNAME,Mbj47Newspaper.PREFIX);
        Mbj47NewspaperDAO dao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * 新聞マスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMbj47NewspaperVO getMasterMaintenanceNewspaper(Mbj47NewspaperCondition condition) throws HAMException {

        FindMbj47NewspaperVO vo = new FindMbj47NewspaperVO();

        if (condition != null) {
            Mbj47NewspaperDAO dcDao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * HM担当者登録データVO登録
     * @param vo HM担当者登録データVO
     * @throws HAMException
     */
    public void registMasterMaintenanceHMUser(RegistMbj48HmUserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(), Mbj48HmUser.TBNAME, Mbj48HmUser.PREFIX);
        Mbj48HmUserDAO dao = Mbj48HmUserDAOFactory.createMbj48HmUserDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC担当者検索データVO取得
     * @param condition 検索条件
     * @return 検索データVO
     * @throws HAMException
     */
    public FindMbj48HmUserVO getMasterMaintenanceHMUser(Mbj48HmUserCondition condition) throws HAMException {

        FindMbj48HmUserVO vo = new FindMbj48HmUserVO();

        if (condition != null) {
            Mbj48HmUserDAO dao = Mbj48HmUserDAOFactory.createMbj48HmUserDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * 媒体(制作)検索データVO取得
     * @param condition 検索条件
     * @return 検索データVO
     * @throws HAMException
     */
    public FindMbj49MediaProductionVO getMasterMaintenanceMediaProduction(Mbj49MediaProductionCondition condition) throws HAMException {

        FindMbj49MediaProductionVO vo = new FindMbj49MediaProductionVO();

        if (condition != null) {
            Mbj49MediaProductionDAO dao = Mbj49MediaProductionDAOFactory.createMbj49MediaProductionDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

    /**
     * 担当者スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceUserSpreadVO getUserSpread(MasterMaintenanceUserSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceUserSpreadVO vo = new FindMasterMaintenanceUserSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getUserSpreadVO(condition));
        }

        return vo;
    }

    /**
     * 車種権限スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceCarAuthoritySpreadVO getCarAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition condition) throws HAMException {

        FindMasterMaintenanceCarAuthoritySpreadVO vo = new FindMasterMaintenanceCarAuthoritySpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getCarAuthoritySpreadVO(condition));
        }

        return vo;
    }

    /**
     * 媒体権限スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceMediaAuthoritySpreadVO getMediaAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition condition) throws HAMException {

        FindMasterMaintenanceMediaAuthoritySpreadVO vo = new FindMasterMaintenanceMediaAuthoritySpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMediaAuthoritySpreadVO(condition));
        }

        return vo;
    }

    /**
     * 車種担当スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceCarUserSpreadVO getCarUserSpread(MasterMaintenanceCarUserSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceCarUserSpreadVO vo = new FindMasterMaintenanceCarUserSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getCarUserSpreadVO(condition));
        }

        return vo;
    }

    /**
     * HC商品スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceHCProductSpreadVO getHCProductSpread(MasterMaintenanceHCProductSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceHCProductSpreadVO vo = new FindMasterMaintenanceHCProductSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getHCProductSpreadVO(condition));
        }

        return vo;
    }

    /**
     * 機能制御スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceFunctionControlSpreadVO getFunctionControlSpread(MasterMaintenanceFunctionControlSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceFunctionControlSpreadVO vo = new FindMasterMaintenanceFunctionControlSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getFunctionControlSpreadVO(condition));
        }

        return vo;
    }

    /**
     * セキュリティスプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceSecuritySpreadVO getSecuritySpread(MasterMaintenanceSecuritySpreadCondition condition) throws HAMException {

        FindMasterMaintenanceSecuritySpreadVO vo = new FindMasterMaintenanceSecuritySpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getSecuritySpreadVO(condition));
        }

        return vo;
    }

    /**
     * 新雑媒体マスタ検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceMEU20MSMZBTVO getMEU20MSMZBT(MasterMaintenanceMEU20MSMZBTCondition condition) throws HAMException {

        FindMasterMaintenanceMEU20MSMZBTVO vo = new FindMasterMaintenanceMEU20MSMZBTVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceMEU20MSMZBTVO(condition));
        }

        return vo;
    }

    /**
     * 経理組織展開テーブル検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDVO getMasterMaintenanceMEU07SIKKRSPRD(MasterMaintenanceMEU07SIKKRSPRDCondition condition) throws HAMException {

        FindMasterMaintenanceMEU07SIKKRSPRDVO vo = new FindMasterMaintenanceMEU07SIKKRSPRDVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceMEU07SIKKRSPRDVO(condition));
        }

        return vo;
    }

    /**
     * 経理組織展開テーブル検索データVO取得（含む検索）
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDVO getMasterMaintenanceMEU07SIKKRSPRDLike(MasterMaintenanceMEU07SIKKRSPRDLikeCondition condition) throws HAMException {

        FindMasterMaintenanceMEU07SIKKRSPRDVO vo = new FindMasterMaintenanceMEU07SIKKRSPRDVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceMEU07SIKKRSPRDVO(condition));
        }

        return vo;
    }

    /**
     * 個人情報View検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceAccUserVO getMasterMaintenanceAccUser(MasterMaintenanceAccUserCondition condition) throws HAMException {

        FindMasterMaintenanceAccUserVO vo = new FindMasterMaintenanceAccUserVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceAccUserVO(condition));
        }

        return vo;
    }

    /**
     * 個人情報View検索データVO取得（含む検索）
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceAccUserVO getMasterMaintenanceAccUserLike(MasterMaintenanceAccUserLikeCondition condition) throws HAMException {

        FindMasterMaintenanceAccUserVO vo = new FindMasterMaintenanceAccUserVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceAccUserVO(condition));
        }

        return vo;
    }

    /**
     * 依頼先検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceFindContactRequestVO getMasterMaintenanceFindContactRequest(FindContactRequestCondition condition) throws HAMException {

        FindMasterMaintenanceFindContactRequestVO vo = new FindMasterMaintenanceFindContactRequestVO();

        if (condition != null) {
            FindContactRequestDAO dao = FindContactRequestDAOFactory.createFindContactRequestDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /* 2016/02/17 HDX対応 HLC K.Oki ADD Start */
    /**
     * 車種担当者(素材)登録データVO登録
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarUserSozai(RegistMbj52SzTntUserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj52SzTntUser.TBNAME,Mbj52SzTntUser.PREFIX);

        Mbj52SzTntUserDAO dao = Mbj52SzTntUserDAOFactory.createMbj52SzTntUserDAO();

        //データ削除
        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }

        //データ登録
        if(vo.getInsertList() != null) {
            for(Mbj52SzTntUserVO mbj52VO : vo.getInsertList()) {
                //新規登録の場合
                if(mbj52VO.getUSERSEQ().intValue() == Integer.parseInt(HAMConstants.ZERO))
                {
                    //最大値(担当者SEQ・ソートNo)格納用変数
                    int MaxUserSeq = 1;
                    int MaxSortNo = 1;

                    //Condition設定
                    Mbj52SzTntUserCondition mbj52Cond = new Mbj52SzTntUserCondition();
                    mbj52Cond.setDcarcd(mbj52VO.getDCARCD());

                    //車種ごとの担当者SEQとソートNoを取得し設定
                    List<Mbj52SzTntUserVO> mbj52Dao = dao.selectVO(mbj52Cond);

                    //テーブルに行が存在する場合
                    if(mbj52Dao.size() > 0) {
                        Mbj52SzTntUserVO UserSeqVo = mbj52Dao.get(Integer.parseInt(HAMConstants.ZERO));
                        Mbj52SzTntUserVO SortNoVo = mbj52Dao.get(Integer.parseInt(HAMConstants.ONE));

                        //取得した車種ごとの担当者SEQとソートNoの値を最大値に設定
                        MaxUserSeq = UserSeqVo.getUSERSEQ().intValue() + 1;
                        MaxSortNo = SortNoVo.getSORTNO().intValue() + 1;
                    }

                    //車種ごとの担当者SEQとソートNoの最大値をそれぞれ設定
                    mbj52VO.setUSERSEQ(new BigDecimal(MaxUserSeq));
                    mbj52VO.setSORTNO(new BigDecimal(MaxSortNo));

                    dao.insertVO(mbj52VO);
                }
                //登録済みの場合
                else
                {
                    dao.insertVO(mbj52VO);
                }
            }
        }
    }

    /**
     * 車種担当者(素材)登録データVO登録(USERID指定)
     *
     * @param vo データVO
     */
    public void registMasterMaintenanceCarUserSozaiUserID(RegistMbj52SzTntUserVO vo) throws HAMException
    {
        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(), Mbj52SzTntUser.TBNAME,Mbj52SzTntUser.PREFIX);

        Mbj52SzTntUserDAO dao = Mbj52SzTntUserDAOFactory.createMbj52SzTntUserDAO();

        //データ削除
        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVOWhereUserID(vo.getDeleteList().get(i));
        }
    }

    /**
     * 車種担当(素材)スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceCarUserSozaiSpreadVO getCarUserSozaiSpread(MasterMaintenanceCarUserSozaiSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceCarUserSozaiSpreadVO vo = new FindMasterMaintenanceCarUserSozaiSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getCarUserSozaiSpreadVO(condition));
        }

        return vo;
    }

    /**
     * セキュリティグループユーザー(HC/HM)スプレッド検索データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FindMasterMaintenanceHCHMSecGrpUserSpreadVO getHCHMSecGrpUserSpread(MasterMaintenanceHCHMSecGrpUserSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceHCHMSecGrpUserSpreadVO vo = new FindMasterMaintenanceHCHMSecGrpUserSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getHCHMSecGrpUserSpreadVO(condition));
        }

        return vo;
    }
    /* 2016/02/17 HDX対応 HLC K.Oki ADD End */

    /**
     * 系列チェック
     *
     * @param vo 対象データ
     */
    public void checkRegistMasterMaintenanceSeries(RegistMbj04KeiretsuVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceSeries(vo.getDeleteList());
        }
    }

    /**
     * 請求先グループチェック
     *
     * @param vo 対象データ
     */
    public void checkRegistMasterMaintenanceDemandGroup(RegistMbj26BillGroupVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceDemandGroup(vo.getDeleteList());
        }
    }

    /**
     * HC部門チェック
     *
     * @param vo 対象データ
     */
    public void checkRegistMasterMaintenanceHCSection(RegistMbj06HcBumonVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceHCSection(vo.getDeleteList());
        }
    }

    /**
     * 設定局チェック
     *
     * @return チェックResult
     * @param vo 対象データ
     */
    public void checkRegistMasterMaintenanceEstablishmentOffice(RegistMbj29SetteiKykVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceEstablishmentOffice(vo.getDeleteList());
        }
    }

    /**
     * 入力担当チェック
     *
     * @return チェックResult
     * @param vo 対象データ
     */
    public void checkRegistMasterMaintenanceInputUser(RegistMbj30InputTntVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceInputUser(vo.getDeleteList());
        }
    }

}
