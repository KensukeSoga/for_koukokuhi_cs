package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj37RdProgramCondition;
import jp.co.isid.ham.common.model.Tbj37RdProgramDAO;
import jp.co.isid.ham.common.model.Tbj37RdProgramDAOFactory;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialCondition;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAOFactory;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialVO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationCondition;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationDAO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationDAOFactory;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * ラジオ番組登録画面登録Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegisterRdProgramInfoManager {

    /** シングルトンインスタンス */
    private static RegisterRdProgramInfoManager _manager = new RegisterRdProgramInfoManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private RegisterRdProgramInfoManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static RegisterRdProgramInfoManager getInstance() {
        return _manager;
    }

    /**
     * ラジオ番組登録画面情報を登録する
     * @param vo ラジオ番組登録画面登録情報VO
     * @return ラジオ番組SEQNO(新規用)
     * @throws HAMException
     */
    public BigDecimal registerRdProgramInfo(RegisterRdProgramInfoVO vo) throws HAMException {

        /* 排他チェック */
        if (!tbj37ExclusionCheck(vo)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }
        if (vo.getTbj38UpdVo() != null && vo.getTbj38UpdVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38vo : vo.getTbj38UpdVo()) {
                if (!tbj38ExclusionCheck(tbj38vo)) {
                    throw new HAMException("排他エラー", "BJ-E0005");
                }
            }
        }
        if (vo.getTbj38DelVo() != null && vo.getTbj38DelVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38vo : vo.getTbj38DelVo()) {
                if (!tbj38ExclusionCheck(tbj38vo)) {
                    throw new HAMException("排他エラー", "BJ-E0005");
                }
            }
        }
        if (vo.getTbj39DelVo() != null && vo.getTbj39DelVo().size() != 0) {
            for (Tbj39RdProgramStationVO tbj39vo : vo.getTbj39DelVo()) {
                if (!tbj39ExclusionCheck(tbj39vo)) {
                    throw new HAMException("排他エラー", "BJ-E0005");
                }
            }
        }
        if (vo.getTbj20UpdVo() != null && vo.getTbj20UpdVo().size() != 0) {
            for (Tbj20SozaiKanriListVO tbj20vo : vo.getTbj20UpdVo()) {
                if (!tbj20ExclusionCheck(tbj20vo)) {
                    throw new HAMException("排他エラー", "BJ-E0005");
                }
            }
        }

        //ラジオ番組SEQNO(新規用)
        BigDecimal rdSeqNo = BigDecimal.valueOf(0);

        /* 素材一覧情報 */
        Tbj20SozaiKanriListDAO tbj20Dao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();

        //更新
        if (vo.getTbj20UpdVo() != null && vo.getTbj20UpdVo().size() != 0) {
            for (Tbj20SozaiKanriListVO tbj20Vo : vo.getTbj20UpdVo()) {
                tbj20Dao.updateVO(tbj20Vo);
            }
        }

        /* ラジオ番組情報 */
        Tbj37RdProgramDAO tbj37Dao = Tbj37RdProgramDAOFactory.createTbj37RdProgramDAO();
        Tbj38RdProgramMaterialDAO tbj38Dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj39RdProgramStationDAO tbj39Dao = Tbj39RdProgramStationDAOFactory.createTbj39RdProgramStationDAO();

        /* ラジオ番組一覧 */
        //追加
        BigDecimal maxRdSeqNo = BigDecimal.valueOf(0);
        if (vo.getTbj37InsVo() != null && vo.getTbj37InsVo().size() != 0) {

            //ラジオ番組SEQNO最大値取得
            Tbj37RdProgramCondition tbj37Cond = new Tbj37RdProgramCondition();
            List<Tbj37RdProgramVO> tbj37VoList = tbj37Dao.selectMaxRdSeqNo(tbj37Cond);
            maxRdSeqNo = tbj37VoList.get(0).getRDSEQNO();

            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37InsVo()) {
                tbj37Vo.setRDSEQNO(maxRdSeqNo);
                tbj37Dao.insertVO(tbj37Vo);

                //ラジオ番組SEQNO(新規用)にセット.
                rdSeqNo = maxRdSeqNo;
            }
        }

        //更新
        if (vo.getTbj37UpdVo() != null && vo.getTbj37UpdVo().size() != 0) {
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37UpdVo()) {
                tbj37Dao.updateVO(tbj37Vo);
            }
        }

        //削除
        if (vo.getTbj37DelVo() != null && vo.getTbj37DelVo().size() != 0) {
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37DelVo()) {
                tbj37Dao.deleteVO(tbj37Vo);
            }
        }

        /* ラジオ番組素材 */
        //追加
        if (vo.getTbj38InsVo() != null && vo.getTbj38InsVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38Vo : vo.getTbj38InsVo()) {
                if (tbj38Vo.getRDSEQNO() == null) {
                    tbj38Vo.setRDSEQNO(maxRdSeqNo);
                }
                tbj38Dao.insertVO(tbj38Vo);
            }
        }
        //更新
        if (vo.getTbj38UpdVo() != null && vo.getTbj38UpdVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38Vo : vo.getTbj38UpdVo()) {
                tbj38Dao.updateVO(tbj38Vo);
            }
        }
        //削除
        if (vo.getTbj38DelVo() != null && vo.getTbj38DelVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38Vo : vo.getTbj38DelVo()) {
                tbj38Dao.deleteVO(tbj38Vo);
            }
        }

        /* ラジオ番組ネット局 */
        //追加
        if (vo.getTbj39InsVo() != null && vo.getTbj39InsVo().size() != 0) {
            for (Tbj39RdProgramStationVO tbj39Vo : vo.getTbj39InsVo()) {
                if (tbj39Vo.getRDSEQNO() == null) {
                    tbj39Vo.setRDSEQNO(maxRdSeqNo);
                }
                tbj39Dao.insertVO(tbj39Vo);
            }
        }
        //削除
        if (vo.getTbj39DelVo() != null && vo.getTbj39DelVo().size() != 0) {
            for (Tbj39RdProgramStationVO tbj39Vo : vo.getTbj39DelVo()) {
                tbj39Dao.deleteVO(tbj39Vo);
            }
        }

        return rdSeqNo;
    }

    /**
     * ラジオ番組情報排他チェック
     * @param vo ラジオ番組登録画面登録情報VO
     * @return boolean true: 正常終了、false : 排他エラー
     * @throws HAMException
     */
    private boolean tbj37ExclusionCheck(RegisterRdProgramInfoVO vo) throws HAMException {

        //更新・削除対象が存在しない場合、処理終了
        if ((vo.getTbj37UpdVo() == null || vo.getTbj37UpdVo().size() == 0)
                && (vo.getTbj37DelVo() == null || vo.getTbj37DelVo().size() == 0)) {
            return true;
        }

        Tbj37RdProgramDAO dao = Tbj37RdProgramDAOFactory.createTbj37RdProgramDAO();
        Tbj37RdProgramCondition cond = new Tbj37RdProgramCondition();

        //更新
        if (vo.getTbj37UpdVo() != null && vo.getTbj37UpdVo().size() != 0) {

            //比較用HashMap生成
            HashMap<BigDecimal, Date> map = new HashMap<BigDecimal, Date>();

            //更新対象全件ループ処理
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37UpdVo()) {
                cond.setRdseqno(tbj37Vo.getRDSEQNO());

                //再検索
                List<Tbj37RdProgramVO> list = dao.selectVO(cond);

                if (list != null && list.size() != 0) {
                    map.put(list.get(0).getRDSEQNO(), list.get(0).getUPDDATE());
                } else {
                    //更新対象の年月のラジオ番組SEQNOが存在しない場合、排他エラー
                    return false;
                }
            }

            //更新対象のラジオ番組SEQNOで更新日時を比較
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37UpdVo()) {

                //更新対象の更新日時＜検索結果の更新日時の場合、排他エラー
                if (tbj37Vo.getUPDDATE().before(map.get(tbj37Vo.getRDSEQNO()))) {
                    return false;
                }
            }
        }

        //削除
        if (vo.getTbj37DelVo() != null && vo.getTbj37DelVo().size() != 0) {

            //比較用HashMap生成
            HashMap<BigDecimal, Date> map = new HashMap<BigDecimal, Date>();

            //削除対象全件ループ処理
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37DelVo()) {
                cond.setRdseqno(tbj37Vo.getRDSEQNO());

                //再検索
                List<Tbj37RdProgramVO> list = dao.selectVO(cond);

                if (list != null && list.size() != 0) {
                    map.put(list.get(0).getRDSEQNO(), list.get(0).getUPDDATE());
                } else {
                    //削除対象の年月のラジオ番組SEQNOが存在しない場合、排他エラー
                    return false;
                }
            }

            //削除対象のラジオ番組SEQNOで更新日時を比較
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37DelVo()) {

                //削除対象の更新日時＜検索結果の更新日時の場合、排他エラー
                if (tbj37Vo.getUPDDATE().before(map.get(tbj37Vo.getRDSEQNO()))) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * ラジオ番組素材情報排他チェック
     * @param vo ラジオ番組素材VO
     * @return boolean true: 正常終了、false : 排他エラー
     * @throws HAMException
     */
    private boolean tbj38ExclusionCheck(Tbj38RdProgramMaterialVO vo) throws HAMException {

        Tbj38RdProgramMaterialDAO dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj38RdProgramMaterialCondition cond = new Tbj38RdProgramMaterialCondition();

        //比較用HashMap生成
        HashMap<BigDecimal, Date> map = new HashMap<BigDecimal, Date>();

        cond.setRdseqno(vo.getRDSEQNO());
        cond.setYearmonth(vo.getYEARMONTH());
        cond.setWakuseq(vo.getWAKUSEQ());

        //再検索
        List<Tbj38RdProgramMaterialVO> list = dao.selectVO(cond);

        if (list != null && list.size() != 0) {
            map.put(list.get(0).getWAKUSEQ(), list.get(0).getUPDDATE());
        } else {
            //更新対象の年月の枠SEQNOが存在しない場合、排他エラー
            return false;
        }

        //更新対象の更新日時＜検索結果の更新日時の場合、排他エラー
        if (vo.getUPDDATE().before(map.get(vo.getWAKUSEQ()))) {
            return false;
        }

        return true;
    }

    /**
     * ラジオ番組ネット局情報排他チェック
     * @param vo ラジオ番組ネット局VO
     * @return boolean true: 正常終了、false : 排他エラー
     * @throws HAMException
     */
    private boolean tbj39ExclusionCheck(Tbj39RdProgramStationVO vo) throws HAMException {

        Tbj39RdProgramStationDAO dao = Tbj39RdProgramStationDAOFactory.createTbj39RdProgramStationDAO();
        Tbj39RdProgramStationCondition cond = new Tbj39RdProgramStationCondition();

        //比較用HashMap生成
        HashMap<String, Date> map = new HashMap<String, Date>();

        //削除対象全件ループ処理
        cond.setRdseqno(vo.getRDSEQNO());
        cond.setStationcd(vo.getSTATIONCD());

        //再検索
        List<Tbj39RdProgramStationVO> list = dao.selectVO(cond);

        if (list != null && list.size() != 0) {
            map.put(list.get(0).getSTATIONCD(), list.get(0).getUPDDATE());
        } else {
            //削除対象の年月の局コードが存在しない場合、排他エラー
            return false;
        }

        //削除対象の更新日時＜検索結果の更新日時の場合、排他エラー
        if (vo.getUPDDATE().before(map.get(vo.getSTATIONCD()))) {
            return false;
        }

        return true;
    }

    /**
     * 素材一覧排他チェック
     * @param vo ラジオ番組登録画面登録情報VO
     * @return boolean true: 正常終了、false : 排他エラー
     * @throws HAMException
     */
    private boolean tbj20ExclusionCheck(Tbj20SozaiKanriListVO vo) throws HAMException {

        Tbj20SozaiKanriListDAO dao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        Tbj20SozaiKanriListCondition cond = new Tbj20SozaiKanriListCondition();

            //比較用HashMap生成
            HashMap<String, Date> map = new HashMap<String, Date>();

            //更新対象全件ループ処理
                cond.setSozaiym(vo.getSOZAIYM());
                cond.setRcode(vo.getRCODE());

                //再検索
                List<Tbj20SozaiKanriListVO> list = dao.FindSozaiKanriByRCode(cond);

                if (list != null && list.size() != 0) {
                    map.put(list.get(0).getRCODE(), list.get(0).getUPDDATE());
                } else {
                    //更新対象の年月の略コードが存在しない場合、排他エラー
                    return false;
                }

                //更新対象の更新日時＜検索結果の更新日時の場合、排他エラー
                if (vo.getUPDDATE().before(map.get(vo.getRCODE()))) {
                    return false;
                }

        return true;
    }

}
