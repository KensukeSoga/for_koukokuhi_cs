package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdCondition;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class CheckListDAO extends AbstractRdbDao {

    /** �������� */
    private GetRepDataForChkListCondition _getRepDataForChkListCondition = null;
    private RepaVbjaMeu07SikKrSprdCondition _repaVbjaMeu07SikKrSprdCondition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode {
        REPDATA, HATKYK, THS,
    };


    private SelSqlMode _SelSqlMode = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public CheckListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {
        String sql = "";

        if (SelSqlMode.REPDATA.equals(_SelSqlMode)) {
            sql = getSelectSQLForREPDATA();
        } else if (SelSqlMode.HATKYK.equals(_SelSqlMode)) {
            sql = getSelectSQLForHATKYK();
        } else if (SelSqlMode.THS.equals(_SelSqlMode)) {
            sql = getSelectSQLForTHS();
        }

        return sql.toString();
    };

    /**
     * ���[�h"REPDATA"��SQL����Ԃ��܂�
     */
    public String getSelectSQLForREPDATA() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("     " + Tbj11CrCreateData.ORDERNO + " ");
        sql.append("    ," + Mbj05Car.CARNM + " ");
        sql.append("    ," + Mbj16CrExpence.EXPNM + " ");
        sql.append("    ," + Tbj11CrCreateData.EXPENSE + " ");
        sql.append("    ," + Tbj11CrCreateData.DETAIL + " ");
        sql.append("    ," + Mbj26BillGroup.GROUPNM + " ");
        sql.append("    ," + Tbj11CrCreateData.DELIVERDAY + " ");
        sql.append("    ," + Tbj11CrCreateData.CLMMONEY + " ");
        sql.append("    ," + Mbj17CrDivision.DIVNM + " ");
        sql.append("    ," + Mbj30InputTnt.INPUTTNT + " ");
        sql.append(" FROM ");
        sql.append("     " + Tbj11CrCreateData.TBNAME + " ");
        sql.append("    ," + Mbj05Car.TBNAME + " ");
        sql.append("    ," + Mbj16CrExpence.TBNAME + " ");
        sql.append("    ," + Mbj26BillGroup.TBNAME + " ");
        sql.append("    ," + Mbj17CrDivision.TBNAME + " ");
        sql.append("    ," + Mbj30InputTnt.TBNAME + " ");
        sql.append(" WHERE ");
        //��������(�Ԏ�}�X�^)
        sql.append("     " + Tbj11CrCreateData.DCARCD    + " = " + Mbj05Car.DCARCD);
        //��������(CR�\�Z�\��ڃ}�X�^)
        sql.append(" AND " + Tbj11CrCreateData.EXPCD    + " = " + Mbj16CrExpence.EXPCD);
        //��������(�����O���[�v�}�X�^)
        sql.append(" AND " + Tbj11CrCreateData.GROUPCD    + " = " + Mbj26BillGroup.GROUPCD + "(+)");
        //��������(CR�敪�}�X�^)
        sql.append(" AND " + Tbj11CrCreateData.DIVCD    + " = " + Mbj17CrDivision.DIVCD + "(+)");
        //��������(���͒S���҃}�X�^)
        sql.append(" AND " + Tbj11CrCreateData.PHASE       + " = " + Mbj30InputTnt.PHASE + "(+)");
        sql.append(" AND " + Tbj11CrCreateData.CLASSDIV    + " = " + Mbj30InputTnt.CLASSDIV + "(+)");
        sql.append(" AND " + Tbj11CrCreateData.INPUTTNTCD  + " = " + Mbj30InputTnt.SEQNO + "(+)");

        //��������(�t�F�C�Y)
        sql.append(" AND " + Tbj11CrCreateData.PHASE    + " = " + ConvertToDBString(_getRepDataForChkListCondition.getPhase()));
        //��������(������)
        sql.append(" AND " + Mbj16CrExpence.DATEFROM + " <= " + ConvertToDBString(_getRepDataForChkListCondition.getFromSeikyuDate()));
        sql.append(" AND " + Mbj16CrExpence.DATETO   + " >= " + ConvertToDBString(_getRepDataForChkListCondition.getToSeikyuDate()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE + " >= " + ConvertToDBString(_getRepDataForChkListCondition.getFromSeikyuDate()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE   + " <= " + ConvertToDBString(_getRepDataForChkListCondition.getToSeikyuDate()));
        //��������(���Ӑ�)
        if (_getRepDataForChkListCondition.getCarList() != null && _getRepDataForChkListCondition.getCarList().length > 0) {
            sql.append(" AND " + Tbj11CrCreateData.DCARCD + " IN ( ");
            for (int i = 0; i < _getRepDataForChkListCondition.getCarList().length; i++) {
                if (i > 0) {
                    sql.append(",");
                }
                sql.append(" " + ConvertToDBString(_getRepDataForChkListCondition.getCarList()[i]) + " ");
            }
            sql.append(" ) ");
        }
        sql.append(" AND " + Tbj11CrCreateData.CLASSDIV    + " = '0'");
        sql.append(" AND " + Tbj11CrCreateData.STPKBN + " = '0' ");
        sql.append(" ORDER BY ");
        sql.append("     " + Mbj05Car.CARNM + " ");
        sql.append("    ," + Tbj11CrCreateData.ORDERNO + " ");

        return sql.toString();
    };



    /**
     * ���[�h"HATKYK"��SQL����Ԃ��܂�
     */
    public String getSelectSQLForHATKYK() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.SIKCDKYK + " AS SIKCDKYK");
        sql.append("    ," + RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ + " AS KYOKUNM");
        sql.append("    ,ListAgg(" + RepaVbjaMeu07SikKrSprd.SIKCD + ", ',') WITHIN GROUP (order by " + RepaVbjaMeu07SikKrSprd.SIKCD + ") AS SIKCD");
        sql.append(" FROM ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(RepaVbjaMeu07SikKrSprd.SIKCD);
        sql.append(" IN (");
        sql.append(_repaVbjaMeu07SikKrSprdCondition.getSikcd());
        sql.append(" )");
        sql.append(" AND ");
//        sql.append(RepaVbjaMeu07SikKrSprd.STARTYMD);
//        sql.append(" <= ");
//        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getStartymd()));
//        sql.append(" AND ");
//        sql.append(RepaVbjaMeu07SikKrSprd.ENDYMD);
//        sql.append(" >= ");
//        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getEndymd()));
        sql.append(" ( ");
        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getStartymd()));
        sql.append(" BETWEEN ");
        sql.append(RepaVbjaMeu07SikKrSprd.STARTYMD);
        sql.append(" AND ");
        sql.append(RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" OR ");
        sql.append(getDBModelInterface().ConvertToDBString(_repaVbjaMeu07SikKrSprdCondition.getEndymd()));
        sql.append(" BETWEEN ");
        sql.append(RepaVbjaMeu07SikKrSprd.STARTYMD);
        sql.append(" AND ");
        sql.append(RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" ) ");
        sql.append(" GROUP BY ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.SIKCDKYK);
        sql.append("    ," + RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ);
        sql.append(" ORDER BY ");
        sql.append("     " + RepaVbjaMeu07SikKrSprd.SIKCDKYK  + " ");
//        sql.append("    ," + RepaVbjaMeu07SikKrSprd.ENDYMD  + " DESC ");

        return sql.toString();
    };



    /**
     * ���[�h"THS"��SQL����Ԃ��܂�
     */
    public String getSelectSQLForTHS() {
        StringBuffer sql = new StringBuffer();

        CheckListThsDataVO vo = (CheckListThsDataVO)getModel();

        sql.append(" SELECT ");
        sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYCD);
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.SEQNO);
        sql.append("    ," + RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI);
        sql.append(" FROM ");
        sql.append("     " + RepaVbjaMeu12ThsKgy.TBNAME + " ");
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(RepaVbjaMeu12ThsKgy.THSKGYCD + " = " + getDBModelInterface().ConvertToDBString(vo.getTHSKGYCD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu12ThsKgy.STARTYMD + " <= " + getDBModelInterface().ConvertToDBString(vo.getSTARTYMD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu12ThsKgy.ENDYMD + " >= " + getDBModelInterface().ConvertToDBString(vo.getENDYMD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.THSKGYCD + " = " + getDBModelInterface().ConvertToDBString(vo.getTHSKGYCD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.SEQNO + " = " + getDBModelInterface().ConvertToDBString(vo.getSEQNO()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.STARTYMD + " <= " + getDBModelInterface().ConvertToDBString(vo.getSTARTYMD()));
        sql.append(" AND ");
        sql.append(RepaVbjaMeu13ThsKgyBmon.ENDYMD + " >= " + getDBModelInterface().ConvertToDBString(vo.getENDYMD()));
        sql.append(" ORDER BY ");
        sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYCD);
        sql.append("    ," + RepaVbjaMeu13ThsKgyBmon.SEQNO);


        return sql.toString();
    };


    /**
     * ��ʂŎw�肵�������Ō������s���A���[�ɏo�͂���f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepDataForChkListHAMVO> findCheckListREPDATA(GetRepDataForChkListCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new RepDataForChkListHAMVO());
        try {
            _SelSqlMode = SelSqlMode.REPDATA;
            _getRepDataForChkListCondition = cond;
            return (List<RepDataForChkListHAMVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ��ʂŎw�肵�������Ō������s���A���[�ɏo�͂���f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCheckListHattyuKykVO> findCheckListHATKYK(RepaVbjaMeu07SikKrSprdCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindCheckListHattyuKykVO());
        try {
            _SelSqlMode = SelSqlMode.HATKYK;
            _repaVbjaMeu07SikKrSprdCondition = cond;
            return (List<FindCheckListHattyuKykVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ���Ӑ於�̂��擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<CheckListThsDataVO> findCheckListTHS(CheckListThsDataVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.THS;
            return (List<CheckListThsDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
